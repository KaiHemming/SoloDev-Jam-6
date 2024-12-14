using Godot;
using System;

public partial class UI : Control
{
	Boolean hasFoundWreath = false;
	Boolean hasFoundGnome = false;
	Boolean hasFoundNutcracker = false;
	public void findItem(String name) {
		HBoxContainer container = (HBoxContainer)this.GetChild(0).GetChild(1);
		switch (name) {
			case "Wreath": 
				((TextureRect)container.GetChild(0)).Modulate = Godot.Colors.White;
				break;
			case "Gnome":
				((TextureRect)container.GetChild(1)).Modulate = Godot.Colors.White;
				break;
			case "Nutcracker":
				((TextureRect)container.GetChild(2)).Modulate = Godot.Colors.White;
				break;
			default:
				GD.Print("Attempted to add non-existent item to GUI");
				break; // ERROR
		}
	
	}
}
