// Copyright 1998-2016 Epic Games, Inc. All Rights Reserved.

#include "IRuleBasedPlugin.h"

// You should place include statements to your module's private header files here.  You only need to
// add includes for headers that are used in most of your module's source files though.


//-------------------
// Include all the CLIPS header and source files
// * A workaround approach, since linking static library doesn't work
#ifndef CLIPS_FILES_INCLUDED
#define CLIPS_FILES_INCLUDED

//#include "clipscpp.h"
//#include "clipscpplib.cpp"

#include "setup.h"

#if __cplusplus > 199711L
#define register      // Deprecated in C++11.
#endif  // #if __cplusplus > 199711L

#include "clips.h"

#endif // !CLIPS_FILES_INCLUDED
