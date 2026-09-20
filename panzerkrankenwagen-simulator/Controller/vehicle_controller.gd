extends VehicleBody3D

# ============================================================
# AMBULANCE VEHICLE CONTROLLER
# ============================================================

@export_group("Vehicle")
@export var is_current_veh: bool = true
@export var mass_value: float = 1200.0

@export_group("Engine")
@export var engine_force_scale: float = 100.0
@export var minimum_engine_force: float = 40.0
@export var maximum_engine_force: float = 25000.0
@export var reverse_force: float = 10000.0

@export_group("Transmission")
@export var automatic: bool = true

# Much stronger low gears for the heavy ambulance.
@export var gear_ratios: Array[float] = [
	0.0,   # Neutral
	12.0,  # 1st
	9.0,   # 2nd
	7.0,   # 3rd
	5.5,   # 4th
	4.0    # 5th
]

@export var differential_ratios: Array[float] = [
	0.0,
	40.0,
	32.0,
	26.0,
	22.0,
	18.0
]

@export var current_gear: int = 1

# Switch to the next gear at these approximate wheel RPM values.
@export var shift_rpm: Array[float] = [
	0.0,
	300.0,
	600.0,
	900.0,
	1200.0
]

@export_group("Steering")
@export var steering_angle: float = 0.4
@export var steering_speed: float = 2.5
@export var steering_return_speed: float = 3.5

@export_group("Brakes")
@export var brake_force: float = 5.0
@export var handbrake_force: float = 10.0

@export_group("Stability")
@export var center_of_mass_offset: Vector3 = Vector3(0.0, -0.4, 0.0)


func _ready() -> void:
	# Make sure the vehicle has the intended mass.
	mass = mass_value

	# Lower the center of mass so the ambulance is less likely
	# to roll over.
	center_of_mass_mode = RigidBody3D.CENTER_OF_MASS_MODE_CUSTOM
	center_of_mass = center_of_mass_offset

	current_gear = 1

	#print("Ambulance ready. Gear: ", current_gear)


func _physics_process(delta: float) -> void:
	if not is_current_veh:
		return

	# ------------------------------------------------------------
	# INPUT
	# ------------------------------------------------------------

	var throttle := Input.get_action_strength("accelerate")
	var reverse := Input.get_action_strength("reverse")

	var steer_input := (
		Input.get_action_strength("turn_left")
		- Input.get_action_strength("turn_right")
	)

	# ------------------------------------------------------------
	# STEERING
	# ------------------------------------------------------------

	var target_steering := steer_input * steering_angle

	var steering_rate := steering_speed

	if abs(steer_input) < 0.01:
		steering_rate = steering_return_speed

	steering = move_toward(
		steering,
		target_steering,
		steering_rate * delta
	)

	# ------------------------------------------------------------
	# SPEED
	# ------------------------------------------------------------

	var velocity_xz := Vector3(
		linear_velocity.x,
		0.0,
		linear_velocity.z
	)

	var speed := velocity_xz.length()

	# ------------------------------------------------------------
	# WHEEL RPM
	# ------------------------------------------------------------

	var rpm := 0.0

	# Use the first traction wheel to estimate wheel RPM.
	var traction_wheel := get_node_or_null("WheelRearLeft")

	if traction_wheel != null:
		rpm = abs(traction_wheel.get_rpm())

	# ------------------------------------------------------------
	# AUTOMATIC TRANSMISSION
	# ------------------------------------------------------------

	if automatic:
		_update_automatic_gear(rpm)

	# ------------------------------------------------------------
	# BRAKING / ENGINE FORCE
	# ------------------------------------------------------------

	brake = 0.0
	engine_force = 0.0

	# Forward
	if throttle > 0.01:

		# Make absolutely sure we are never trying to drive
		# with the gearbox in neutral.
		if current_gear <= 0:
			current_gear = 1

		var gear_ratio := gear_ratios[current_gear]
		var differential := differential_ratios[current_gear]

		# Base torque.
		var torque := throttle * gear_ratio * differential

		# Convert the M.A.V.S.-style torque calculation into
		# a much stronger VehicleBody3D engine force.
		var force := torque * engine_force_scale

		# Never let the ambulance have less than the minimum
		# force needed to actually start moving.
		force = max(force, minimum_engine_force)

		# Prevent absurd forces while debugging.
		engine_force = min(force, maximum_engine_force)

	# Reverse
	elif reverse > 0.01:

		# If we're already moving forward, brake first.
		if speed > 1.0:
			brake = brake_force
		else:
			engine_force = -reverse_force

	# No throttle
	else:
		engine_force = 0.0

	# ------------------------------------------------------------
	# HANDBRAKE
	# ------------------------------------------------------------

	if Input.is_action_pressed("ui_accept"):
		brake = handbrake_force
		engine_force = 0.0


func _update_automatic_gear(rpm: float) -> void:
	# Never allow automatic transmission to remain in neutral.
	if current_gear < 1:
		current_gear = 1

	# Shift up.
	if current_gear < gear_ratios.size() - 1:

		var shift_threshold := 1000.0

		if current_gear - 1 < shift_rpm.size():
			shift_threshold = shift_rpm[current_gear - 1]

		if rpm > shift_threshold:
			current_gear += 1

	# Shift down.
	if current_gear > 1:

		var downshift_threshold := 200.0

		if rpm < downshift_threshold:
			current_gear -= 1
