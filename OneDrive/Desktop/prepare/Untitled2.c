#include <windows.h>

// Global variables
HWND hwndEdit, hwndListBox, hwndNewWindow, hwndNewEdit;
#define MAX_STRING_LENGTH 100
#define ID_EDIT 1
#define ID_SAVE 2
#define ID_DELETE 3

LRESULT CALLBACK NewWindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    switch (uMsg) {
        case WM_CREATE: {
            hwndNewEdit = CreateWindowEx(0, "EDIT", "", WS_CHILD | WS_VISIBLE | WS_BORDER, 10, 10, 200, 30, hwnd, NULL, NULL, NULL);
            CreateWindowEx(0, "BUTTON", "Save", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON, 10, 50, 80, 30, hwnd, (HMENU)ID_SAVE, NULL, NULL);
            CreateWindowEx(0, "BUTTON", "Delete", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON, 100, 50, 80, 30, hwnd, (HMENU)ID_DELETE, NULL, NULL);
            break;
        }
        case WM_COMMAND:
            switch (LOWORD(wParam)) {
                case ID_SAVE: { // Save button clicked
                    int selectedIndex = SendMessage(hwndListBox, LB_GETCURSEL, 0, 0);
                    if (selectedIndex != LB_ERR) {
                        int textLength = GetWindowTextLength(hwndNewEdit);
                        char* str = (char*)malloc(textLength + 1);
                        GetWindowText(hwndNewEdit, str, textLength + 1);
                        SendMessage(hwndListBox, LB_DELETESTRING, selectedIndex, 0);
                        SendMessage(hwndListBox, LB_INSERTSTRING, selectedIndex, (LPARAM)str);
                        free(str);
                    }
                    break;
                }
                case ID_DELETE: { // Delete button clicked
                    int selectedIndex = SendMessage(hwndListBox, LB_GETCURSEL, 0, 0);
                    if (selectedIndex != LB_ERR) {
                        SendMessage(hwndListBox, LB_DELETESTRING, selectedIndex, 0);
                    }
                    break;
                }
            }
            break;
        case WM_CLOSE:
            DestroyWindow(hwnd);
            break;
        default:
            return DefWindowProc(hwnd, uMsg, wParam, lParam);
    }
    return 0;
}

LRESULT CALLBACK ButtonProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    switch (uMsg) {
        case WM_COMMAND:
            if (LOWORD(wParam) == ID_EDIT) { // Edit button clicked
                int selectedIndex = SendMessage(hwndListBox, LB_GETCURSEL, 0, 0);
                if (selectedIndex != LB_ERR) {
                    int textLength = SendMessage(hwndListBox, LB_GETTEXTLEN, selectedIndex, 0);
                    char* str = (char*)malloc(textLength + 1);
                    SendMessage(hwndListBox, LB_GETTEXT, selectedIndex, (LPARAM)str);
                    hwndNewWindow = CreateWindowEx(0, "New Window Class", "Edit Item", WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, 300, 200, NULL, NULL, NULL, NULL);
                    ShowWindow(hwndNewWindow, SW_SHOW);
                    SetWindowText(hwndNewEdit, str);
                    free(str);
                } else {
                    MessageBox(hwnd, "Please select an item to edit.", "Edit Error", MB_OK | MB_ICONERROR);
                }
            }
            break;
        default:
            return DefWindowProc(hwnd, uMsg, wParam, lParam);
    }
    return 0;
}

LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    switch (uMsg) {
        case WM_CREATE: {
            hwndEdit = CreateWindowEx(0, "EDIT", "", WS_CHILD | WS_VISIBLE | WS_BORDER, 10, 10, 200, 30, hwnd, NULL, NULL, NULL);
            hwndListBox = CreateWindowEx(0, "LISTBOX", "", WS_CHILD | WS_VISIBLE | WS_BORDER | LBS_NOTIFY | WS_VSCROLL, 10, 50, 200, 150, hwnd, NULL, NULL, NULL);
            CreateWindowEx(0, "BUTTON", "Save", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON, 220, 10, 80, 30, hwnd, (HMENU)ID_SAVE, NULL, NULL);
            CreateWindowEx(0, "BUTTON", "Edit", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON, 220, 50, 80, 30, hwnd, (HMENU)ID_EDIT, NULL, NULL);
            break;
        }
        case WM_COMMAND:
            switch (LOWORD(wParam)) {
                case ID_SAVE: // Save button clicked
                case ID_EDIT: // Edit button clicked
                    return ButtonProc(hwnd, uMsg, wParam, lParam);
                default:
                    return DefWindowProc(hwnd, uMsg, wParam, lParam);
            }
        case WM_DESTROY:
            PostQuitMessage(0);
            break;
        default:
            return DefWindowProc(hwnd, uMsg, wParam, lParam);
    }
    return 0;
}

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow) {
    // Register the window class
    const char *CLASS_NAME = "Sample Window Class";
    const char *NEW_WINDOW_CLASS_NAME = "New Window Class";

    WNDCLASS wc = {};
    wc.lpfnWndProc = WindowProc;
    wc.hInstance = hInstance;
    wc.lpszClassName = CLASS_NAME;

    RegisterClass(&wc);

    WNDCLASS wcNew = {};
    wcNew.lpfnWndProc = NewWindowProc;
    wcNew.hInstance = hInstance;
    wcNew.lpszClassName = NEW_WINDOW_CLASS_NAME;

    RegisterClass(&wcNew);

    // Create the window
    HWND hwnd = CreateWindowEx(
        0,
        CLASS_NAME,
        "Simple Text Editor",
        WS_OVERLAPPEDWINDOW,
        CW_USEDEFAULT, CW_USEDEFAULT, 400, 300,
        NULL,
        NULL,
        hInstance,
        NULL
    );

    if (hwnd == NULL) {
        return 0;
    }

    // Show the window
    ShowWindow(hwnd, nCmdShow);

    // Run the message loop
    MSG msg = {};
    while (GetMessage(&msg, NULL, 0, 0)) {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    return 0;
}

