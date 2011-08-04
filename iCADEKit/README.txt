______________________________________________________________________________________________________________
Copyright (C) 2011 by Appracatappra, LLC.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
______________________________________________________________________________________________________________


ABOUT THIS API
--------------

This API provides support for the Ion Audio iCADE to any MonoTouch application by either building the iCADEKit
project into a .dll and including the resulting .dll into a project or by directly including the iCADEController
class into your project and directly compiling it into your application.


HOW TO USE
----------

The iCADEController class supports two methods of communication to the iCADE device:

1) Either by attaching code directly to the specific iCADEController event like ButtonTopLeftPressed
2) Or by polling public properties of the iCADEController like buttonTopLeftDepressed

To use include the MonoTouch.iCADE namespace in your project, create a new instance of the iCADEController and add it
to your game's primary view.



ENUMERATIONS
------------

iCADEMoveDirection
Denotes the current direction that the iCADE joystick is pointing to and contains the following members:

none - the joystick is in the neutral, center position
left - the joystick is in the left position
right - the joystick is in the right position
up - the joystick is in the up position
down - the joystick is in the down position


PUBLIC PROPERTIES
-----------------

The following properties are defined for this class and can be used to poll the state of the iCADE:

iCADEDetected - returns TRUE if the iCADE has been detected else FALSE
moveDirection - returns the last direction that the iCADE joystick was in
buttonTopLeftDepressed - the top left button is currently being held down
buttonTopLeftMiddleDepressed - the top left middle button is currently being held down
buttonTopRightMiddleDepressed - the top right middle button is currently being held down 
buttonTopRightDepressed - the top right button is currently being held down
buttonBottomLeftDepressed - the bottom left button is currently being held down
buttonBottomLeftMiddleDepressed - the bottom left middle button is currently being held down
buttonBottomRightMiddleDepressed - the bottom right middle button is currently being held down 
buttonBottomRightDepressed - the bottom right button is currently being held down


PUBLIC EVENTS
-------------

The following events will be raised based on the state of the iCADE:

DetectediCADE - raised when the iCADE is first detected by the API
JoystickUpPressed - raised when the joystick is moved to the top
JoystickUpReleased - raised when the joystick is moved from the top
JoysitckDownPressed - raised when the joystick is moved to the bottom
JoystickDownReleased - raised when the joystick is moved from the bottom
JoystickLeftPressed - raised when the joystick is moved to the left
JoystickLeftReleased - raised when the joystick is move from the left
JoystickRightPressed - raised when the joystick is move to the right
JoystickRightReleased - raised when the joystick is move from the right
JoystickMoved - raised whenever the joystick changes position
ButtonTopLeftPressed - raised when the top left button is pressed
ButtonTopLeftReleased - raised when the top left button is released
ButtonTopLeftMiddlePressed - raised when the top left middle button is pressed
ButtonTopLeftMiddleReleased - raised when the top left middle button is released
ButtonTopRightMiddlePressed - raised when the top right middle button is pressed
ButtonTopRightMiddleReleased - raised when the top right middle button is released
ButtonTopRightPressed - raised when the top right button is presssed
ButtonTopRightReleased - raised when the top right button is released
ButtonBottomLeftPressed - raised when the bottom left button is pressed
ButtonBottomLeftReleased - raised when the bottom left button is released
ButtonBottomLeftMiddlePressed - raised when the bottom left middle button is pressed
ButtonBottomLeftMiddleReleased - raised when the bottom left middle button is released
ButtonBottomRightMiddlePressed - raised when the bottom right middle button is pressed
ButtonBottomRightMiddleReleased - raised when the bottom right middle button is released
ButtonBottomRightPressed - raised when the bottom right button is presssed
ButtonBottomRightReleased - raised when the bottom right button is released
