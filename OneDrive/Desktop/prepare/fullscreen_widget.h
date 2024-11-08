// fullscreen_widget.h

#ifndef FULLSCREEN_WIDGET_H
#define FULLSCREEN_WIDGET_H

#include <windows.h>

// Function to handle messages for the fullscreen window
LRESULT CALLBACK FullscreenWindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

// Function to create a fullscreen window with widgets
HWND CreateFullscreenWindowWithWidgets(HINSTANCE hInstance, const char* className, const char* windowTitle);

#endif // FULLSCREEN_WIDGET_H

