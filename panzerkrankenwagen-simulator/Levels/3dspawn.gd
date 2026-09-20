extends Node3D

var numPaitent := 0
@export var max_numP: int = 80

var point1: Vector3
var point2: Vector3

@onready var patient_BP: Resource = preload("res://Assets/MapPieces/patient.tscn")

func _ready() -> void:
	randomize()
	point1 = $Visualizer3D/Point1.position
	point2 = $Visualizer3D/Point2.position
	
func get_random_point_inside(p1: Vector3, p2: Vector3) -> Vector3:
	var x_value: float = randf_range(p1.x, p2.x)
	var z_value: float = randf_range(p1.z, p2.z)
	
	
	var random_point_inside: Vector3 = Vector3(x_value, 0, z_value)
	
	return (random_point_inside)

func spawn_Paitent():
	var paitent_instance: Node = patient_BP.instantiate()
	
	add_child(paitent_instance)
	
	var spawn_location: Vector3 = get_random_point_inside(point1, point2)
	
	paitent_instance.position = spawn_location

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	while(numPaitent < max_numP):
		spawn_Paitent()
		numPaitent+=1
	
