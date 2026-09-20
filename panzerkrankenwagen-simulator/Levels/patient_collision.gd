
extends Area3D

class_name patient_collision

var score := 0
var patientsColl := 0
signal item_collected(item: String, value: int)

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass


func _on_area_entered(body: Area3D) -> void:
	print("collision")
	if body is CollectablePatient:
		var item = body as CollectablePatient
		
		patientsColl+=1
		score+=item.score_value
		
		item_collected.emit(item.item_type, item.score_value)
		
		item.collect()
