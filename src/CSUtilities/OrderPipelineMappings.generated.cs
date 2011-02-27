 
 
 
//////////////////////////////////////////////////////////////////////
//
// Summary:		Represents a T4 text template used for generating strongly-typed
//				classes for dictionary keys represented in the OrderPipelineMappings.xml 
//				file for the Commerce Server 2007 Order Object System.
//
// Usage:		Copy the OrderPipelineMappings.tt file to the class library/project
//				in which you want to be able to expose the Commerce Server properties.
//		
//				Configuration of class visibility, class name, namespace 
//				and more are done in the last section of this file.
//
// Issues:		Changes you make in the OrderPipelineMappings.xml file are not automatically
//				reflected in the generated code. 
//				But you can just open this file and save it again to run the tool.
//
//				Customization tip:
//				Free edition of T4 editor tool from tangible-engineering
//				can be used to get syntax highlighting in Visual Studio.
//
///////////////////////////////////////////////////////////////////////
//
// February/2011 by
// Brian Holmgård Kristensen, author of CSUtilities
// blog.brianh.dk / CommerceServerTraining.com
//
// All information, source code, and especially tools are 
// provided as is and on a "use at your own risk" basis.
//
///////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSUtilities
{
    public partial class OrderPipelineMappings
    {
