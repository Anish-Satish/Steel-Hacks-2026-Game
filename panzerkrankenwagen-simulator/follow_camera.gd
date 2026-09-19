extends Camera3D

@export var distance: float = 4.0
@export var height: float = 2
@export var look_height: float = 0.5

func _ready():
	top_level = true

func _physics_process(_delta):
	var target = get_parent().global_position

	# Vehicle's forward direction is -Z, so +Z is behind it.
	var behind = get_parent().global_transform.basis.z.normalized()

	var target_position = target + behind * distance
	target_position.y += height

	global_position = target_position

	look_at(target + Vector3.UP * look_height, Vector3.UP)