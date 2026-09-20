extends Camera3D

@export var distance: float = 8.0
@export var height: float = 5.0
@export var look_height: float = 1.2
@export var position_smoothing: float = 6.0
@export var rotation_smoothing: float = 7.0
@export var max_extra_distance: float = 3.0
@export var speed_for_max_distance: float = 20.0
@export var look_ahead: float = 4.0
@export var collision_margin: float = 0.5
@export var minimum_distance: float = 2.5

func _ready():
	top_level = true

func _physics_process(delta):
	var vehicle = get_parent() as VehicleBody3D

	if vehicle == null:
		return

	var target = vehicle.global_position

	# Vehicle's forward direction is -Z, so +Z is behind it.
	var forward = -vehicle.global_transform.basis.z.normalized()
	var behind = -forward

	var speed = vehicle.linear_velocity.length()
	var speed_factor = clamp(speed / speed_for_max_distance, 0.0, 1.0)
	var dynamic_distance = distance + max_extra_distance * speed_factor

	var target_position = target + behind * dynamic_distance
	target_position.y += height

	# Move the camera closer if something is blocking it.
	var space_state = vehicle.get_world_3d().direct_space_state

	var query = PhysicsRayQueryParameters3D.create(
		target + Vector3.UP * look_height,
		target_position
	)

	query.exclude = [vehicle]

	var result = space_state.intersect_ray(query)

	if result:
		var direction = (target_position - target).normalized()
		target_position = result.position - direction * collision_margin

		var current_distance = (target_position - target).length()

		if current_distance < minimum_distance:
			target_position = target + direction * minimum_distance

	var position_weight = 1.0 - exp(-position_smoothing * delta)

	global_position = global_position.lerp(
		target_position,
		position_weight
	)

	var look_target = target + Vector3.UP * look_height + forward * look_ahead

	look_at(
		look_target,
		Vector3.UP
	)
