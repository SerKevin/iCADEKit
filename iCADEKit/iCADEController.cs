using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace MonoTouch.iCADE
{
	/// <summary>
	/// Enum to return to direction last indicated by the iCADE's joystick
	/// </summary>
	public enum iCADEMoveDirection {
		none,
		left,
		right,
		up,
		down
	}
	
	/// <summary>
	/// Specialized UITextField that can be added to a game and will act as an iCADE 
	/// interface. Support events that are raised when a control is pressed or released
	/// as well as a set of properties that can be used to continiously poll the state
	/// of the iCADE device.
	/// </summary>
	public partial class iCADEController : UITextField
	{
		//Private properties
		private bool _iCADEDetected=false;
		private iCADEMoveDirection _direction=iCADEMoveDirection.none;
		private bool _buttonTopLeftDepressed=false;
		private bool _buttonTopLeftMiddleDepressed=false;
		private bool _buttonTopRightMiddleDepressed=false;
		private bool _buttonTopRightDepressed=false;
		private bool _buttonBottomLeftDepressed=false;
		private bool _buttonBottomLeftMiddleDepressed=false;
		private bool _buttonBottomRightMiddleDepressed=false;
		private bool _buttonBottomRightDepressed=false;
		
		#region Constructors
		public iCADEController() : base() {
			//Auto position outside of screen view
			this.Frame=new RectangleF(-100,-100,100,32);
			this.Initialize();
		}
		
		public iCADEController(NSCoder coder) : base(coder) {
			this.Initialize();
		}
		
		public iCADEController(NSObjectFlag t) : base(t) {
			this.Initialize();
		}
		
		public iCADEController(IntPtr handel) : base(handel) {
			this.Initialize();
		}
		
		public iCADEController(RectangleF frame) : base(frame) {
			this.Initialize();
		}
		#endregion
		
		#region Public Properties
		public bool iCADEDetected {
			get{return _iCADEDetected;}
			set{_iCADEDetected=value;}
		}
		
		public iCADEMoveDirection moveDirection{
			get{return _direction;}	
		}
		
		public bool buttonTopLeftDepressed {
			get{return _buttonTopLeftDepressed;}	
		}
		
		public bool buttonTopLeftMiddleDepressed {
			get{return _buttonTopLeftMiddleDepressed;}	
		}
		
		public bool buttonTopRightMiddleDepressed {
			get{return _buttonTopRightMiddleDepressed;}	
		}
		
		public bool buttonTopRightDepressed {
			get{return _buttonTopRightDepressed;}	
		}
		
		public bool buttonBottomLeftDepressed {
			get{return _buttonBottomLeftDepressed;}	
		}
		
		public bool buttonBottomLeftMiddleDepressed {
			get{return _buttonBottomLeftMiddleDepressed;}	
		}
		
		public bool buttonBottomRightMiddleDepressed {
			get{return _buttonBottomRightMiddleDepressed;}	
		}
		
		public bool buttonBottomRightDepressed {
			get{return _buttonBottomRightDepressed;}	
		}
		#endregion
		
		#region Events
		public delegate void iCADEControlDelegate();
		public delegate void iCADEJoystickMovedDelegate(iCADEMoveDirection direction);
		
		public event iCADEControlDelegate DetectediCADE;
		
		public event iCADEControlDelegate JoystickUpPressed;
		public event iCADEControlDelegate JoystickUpReleased;
		
		public event iCADEControlDelegate JoystickDownPressed;
		public event iCADEControlDelegate JoystickDownReleased;
		
		public event iCADEControlDelegate JoystickLeftPressed;
		public event iCADEControlDelegate JoystickLeftReleased;
		
		public event iCADEControlDelegate JoystickRightPressed;
		public event iCADEControlDelegate JoystickRightReleased;
		
		public event iCADEJoystickMovedDelegate JoystickMoved;
		
		public event iCADEControlDelegate ButtonTopLeftPressed;
		public event iCADEControlDelegate ButtonTopLeftReleased;
		
		public event iCADEControlDelegate ButtonTopLeftMiddlePressed;
		public event iCADEControlDelegate ButtonTopLeftMiddleReleased;
		
		public event iCADEControlDelegate ButtonTopRightMiddlePressed;
		public event iCADEControlDelegate ButtonTopRightMiddleReleased;
		
		public event iCADEControlDelegate ButtonTopRightPressed;
		public event iCADEControlDelegate ButtonTopRightReleased;
		
		public event iCADEControlDelegate ButtonBottomLeftPressed;
		public event iCADEControlDelegate ButtonBottomLeftReleased;
		
		public event iCADEControlDelegate ButtonBottomLeftMiddlePressed;
		public event iCADEControlDelegate ButtonBottomLeftMiddleReleased;
		
		public event iCADEControlDelegate ButtonBottomRightMiddlePressed;
		public event iCADEControlDelegate ButtonBottomRightMiddleReleased;
		
		public event iCADEControlDelegate ButtonBottomRightPressed;
		public event iCADEControlDelegate ButtonBottomRightReleased;
		#endregion
		
		#region Private Methods
		private void Initialize() {
			
			//Attach listner to text entry field
			this.ShouldChangeCharacters= delegate(UITextField field, NSRange range, string newValue){
				
				//Has the iCADE already been detected?
				if (!_iCADEDetected) {
					_iCADEDetected=true;
					
					//Inform caller	
					if (this.DetectediCADE!=null) this.DetectediCADE();
				}
				
				//Take action based on character returned by icade
				switch(newValue){
				case "w":
					_direction=iCADEMoveDirection.up;
					if (this.JoystickMoved!=null) this.JoystickMoved(_direction);
					if (this.JoystickUpPressed!=null) this.JoystickUpPressed();
					break;
				case "e":
					_direction=iCADEMoveDirection.none;
					if (this.JoystickMoved!=null) this.JoystickMoved(_direction);
					if (this.JoystickUpReleased!=null) this.JoystickUpReleased();
					break;
				case "x":
					_direction=iCADEMoveDirection.down;
					if (this.JoystickMoved!=null) this.JoystickMoved(_direction);
					if (this.JoystickDownPressed!=null) this.JoystickDownPressed();
					break;
				case "z":
					_direction=iCADEMoveDirection.none;
					if (this.JoystickMoved!=null) this.JoystickMoved(_direction);
					if (this.JoystickDownReleased!=null) this.JoystickDownReleased();
					break;
				case "a":
					_direction=iCADEMoveDirection.left;
					if (this.JoystickMoved!=null) this.JoystickMoved(_direction);
					if (this.JoystickLeftPressed!=null) this.JoystickLeftPressed();
					break;
				case "q":
					_direction=iCADEMoveDirection.none;
					if (this.JoystickMoved!=null) this.JoystickMoved(_direction);
					if (this.JoystickLeftReleased!=null) this.JoystickLeftReleased();
					break;
				case "d":
					_direction=iCADEMoveDirection.right;
					if (this.JoystickMoved!=null) this.JoystickMoved(_direction);
					if (this.JoystickRightPressed!=null) this.JoystickRightPressed();
					break;
				case "c":
					_direction=iCADEMoveDirection.none;
					if (this.JoystickMoved!=null) this.JoystickMoved(_direction);
					if (this.JoystickRightReleased!=null) this.JoystickRightReleased();
					break;
				case "y":
					_buttonTopLeftDepressed=true;
					if (this.ButtonTopLeftPressed!=null) this.ButtonTopLeftPressed();
					break;
				case "t":
					_buttonTopLeftDepressed=false;
					if (this.ButtonTopLeftReleased!=null) this.ButtonTopLeftReleased();
					break;
				case "u":
					_buttonTopLeftMiddleDepressed=true;
					if (this.ButtonTopLeftMiddlePressed!=null) this.ButtonTopLeftMiddlePressed();
					break;
				case "f":
					_buttonTopLeftMiddleDepressed=false;
					if (this.ButtonTopLeftMiddleReleased!=null) this.ButtonTopLeftMiddleReleased();
					break;
				case "i":
					_buttonTopRightMiddleDepressed=true;
					if (this.ButtonTopRightMiddlePressed!=null) this.ButtonTopRightMiddlePressed();
					break;
				case "m":
					_buttonTopRightMiddleDepressed=false;
					if (this.ButtonTopRightMiddleReleased!=null) this.ButtonTopRightMiddleReleased();
					break;
				case "o":
					_buttonTopRightDepressed=true;
					if (this.ButtonTopRightPressed!=null) this.ButtonTopRightPressed();
					break;
				case "g":
					_buttonTopRightDepressed=false;
					if (this.ButtonTopRightReleased!=null) this.ButtonTopRightReleased();
					break;
					
				case "h":
					_buttonBottomLeftDepressed=true;
					if (this.ButtonBottomLeftPressed!=null) this.ButtonBottomLeftPressed();
					break;
				case "r":
					_buttonBottomLeftDepressed=false;
					if (this.ButtonBottomLeftReleased!=null) this.ButtonBottomLeftReleased();
					break;
				case "j":
					_buttonBottomLeftMiddleDepressed=true;
					if (this.ButtonBottomLeftMiddlePressed!=null) this.ButtonBottomLeftMiddlePressed();
					break;
				case "n":
					_buttonBottomLeftMiddleDepressed=false;
					if (this.ButtonBottomLeftMiddleReleased!=null) this.ButtonBottomLeftMiddleReleased();
					break;
				case "k":
					_buttonBottomRightMiddleDepressed=true;
					if (this.ButtonBottomRightMiddlePressed!=null) this.ButtonBottomRightMiddlePressed();
					break;
				case "p":
					_buttonBottomRightMiddleDepressed=false;
					if (this.ButtonBottomRightMiddleReleased!=null) this.ButtonBottomRightMiddleReleased();
					break;
				case "l":
					_buttonBottomRightDepressed=true;
					if (this.ButtonBottomRightPressed!=null) this.ButtonBottomRightPressed();
					break;
				case "v":
					_buttonBottomRightDepressed=false;
					if (this.ButtonBottomRightReleased!=null) this.ButtonBottomRightReleased();
					break;
				}
				
				//Keep character from "entering" into text field
				return false;
			};
			
			//Prevent onscreen keyboard from being displayed
			this.InputView=new UIView();
			
			//Force to become first responder
			this.BecomeFirstResponder();
		}
		#endregion
	}
}

