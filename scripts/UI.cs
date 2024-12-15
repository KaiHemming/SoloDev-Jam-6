using Godot;
using System;

public partial class UI : Control
{
	int numFound = 0;
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
			case "Teddy":
				((TextureRect)container.GetChild(3)).Modulate = Godot.Colors.White;
				break;
			case "Stocking":
				((TextureRect)container.GetChild(4)).Modulate = Godot.Colors.White;
				break;
			default:
				GD.Print("Attempted to add non-existent item to GUI");
				break; // ERROR
		}
		numFound++;
		DisplayFoundMessage();
	}
	public async void DisplayFoundMessage() {
		Label congratulationMessage = (Label)this.GetChild(1);
		GD.Print(numFound);
		if (numFound == 5) {
			// Found all items, change message.
			congratulationMessage.Text = "I found all the decorations! Yippee!";
		}
		if (numFound == 2) {
			congratulationMessage.Text = "I found another decoration, cute!";
		}
		congratulationMessage.Visible = true;
		await ToSignal(GetTree().CreateTimer(3f), SceneTreeTimer.SignalName.Timeout);
		if (numFound == 5) {
			congratulationMessage.Text = "Thanks for playing!";
		} else {
			congratulationMessage.Visible = false;
		}
	}
}
