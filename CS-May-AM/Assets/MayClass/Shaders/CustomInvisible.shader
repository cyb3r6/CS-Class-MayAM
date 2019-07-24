//Apply following script to invisible object that will make other objects transparent 
Shader "Custom/InvisibleMask"	//make sure you named your shader file InvisibleMask
{
	SubShader
	{
	  Tags { "Queue" = "Transparent+1" }    // renders after all transparent objects (queue = 3001)
	  Pass {  Blend Zero One }    // makes this object transparent
	}
}