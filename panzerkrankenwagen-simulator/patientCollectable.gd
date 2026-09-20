extends Area3D
class_name CollectablePatient

@export var score_value: int=10
@export var item_type: String = "patient"

func collect():
	queue_free()
