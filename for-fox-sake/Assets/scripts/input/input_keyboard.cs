using UnityEngine;

public class input_keyboard : MonoBehaviour, input_interface
{
	static public KeyCode up = KeyCode.UpArrow;
	static public KeyCode down = KeyCode.DownArrow;
	static public KeyCode left = KeyCode.LeftArrow;
	static public KeyCode right = KeyCode.RightArrow;

	bool input_interface.up()
	{
		return Input.GetKey( input_keyboard.up );
	}

	bool input_interface.up_pressed()
	{
		return Input.GetKeyDown( input_keyboard.up );
	}

	bool input_interface.up_released()
	{
		return Input.GetKeyUp( input_keyboard.up );
	}

	bool input_interface.down()
	{
		return Input.GetKey( input_keyboard.down );
	}

	bool input_interface.down_pressed()
	{
		return Input.GetKeyDown( input_keyboard.down );
	}

	bool input_interface.down_released()
	{
		return Input.GetKeyUp( input_keyboard.down );
	}

	bool input_interface.left()
	{
		return Input.GetKey( input_keyboard.left );
	}

	bool input_interface.left_pressed()
	{
		return Input.GetKeyDown( input_keyboard.left );
	}

	bool input_interface.left_released()
	{
		return Input.GetKeyUp( input_keyboard.left );
	}

	bool input_interface.right()
	{
		return Input.GetKey( input_keyboard.right );
	}

	bool input_interface.right_pressed()
	{
		return Input.GetKeyDown( input_keyboard.right );
	}

	bool input_interface.right_released()
	{
		return Input.GetKeyUp( input_keyboard.right );
	}
}
