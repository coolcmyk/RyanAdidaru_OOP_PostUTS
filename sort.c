//Nama Anggota 
//Name: Teufik Ali Hadzalic 
//NPM: 2306267012 
//Name: Ryan Adidaru Excel Barnabi 
//NPM: 2306266994 
//Date: 22/2/2024 
//Group: 3 
//Judul Program : Tugas 4 (Sorting Algorithm Bubblesort + Searching Algorithm) 
//Versi : 1.2
//referensi: https://www.programiz.com/c-programming/library-function/string.h/strcmp, https://www.geeksforgeeks.org/bubble-sort/
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include "menuBubblesort.h"

int main() {
    int choice,choiceIN,choiceINN;
    do {
        printf("\nMenu:\n");
		printf("1. Rank Students\n");
		printf("2. Input Student's Data\n");
		printf("3. Search And Edit Student's Data'\n");
		printf("4: User's Guide\n");
		printf("5: Exit Program\n");


        
        printf("Enter your choice (0 for clear): ");
        scanf("%d", &choice);
	
        switch (choice) {
        	case 0:
        		system("cls");
        		break;
            case 1:
            	printf("Choose The Method: \n");
            	printf("1.  By Name\n");
            	printf("2.  By Final Score\n");
            	printf("3.  Back to Menu\n");
            	
            	scanf("%d",&choiceIN);
            	switch (choiceIN){
            		case 1:
	            		printf("Choose The Method: \n");
		            	printf("1.  Ascending Order\n");
		            	printf("2.  Descending Order\n");
		            	printf("3.  Back to Menu\n");
		            	
		            	scanf("%d",&choiceIN);
		            	switch (choiceIN){
		            		case 1:
		            			kalkulasi(1);
		            			break;
		            		case 2:
		            			kalkulasi(5);
		            			break;
		            		case 3:
		            			system("cls");
		            			break;
		            		default:
		            			printf("Invalid choice. Please enter a valid option.\n");
						}
		                break;
            		case 2:
            			printf("Choose The Method: \n");
		            	printf("1.  Ascending Order\n");
		            	printf("2.  Descending Order\n");
		            	printf("3.  Back to Menu\n");
		            	
		            	scanf("%d",&choiceIN);
		            	switch (choiceIN){
		            		case 1:
		            			kalkulasi(2);
		            			break;
		            		case 2:
		            			kalkulasi(4);
		            			break;
		            		case 3:
		            			system("cls");
		            			break;
		            		default:
		            			printf("Invalid choice. Please enter a valid option.\n");
						}
            			
            		case 3:
            			system("cls");
            			break;
            		default:
            			printf("Invalid choice. Please enter a valid option.\n");
				}
                break;
            case 2:
                kalkulasi(3);
                break;
            case 3:
            	printf("\n Choose The Method: \n");
            	printf("1.  Search By Status\n");
            	printf("2.  Search And Edit Student's Data\n");
            	printf("3.  Search By Final Score's Range'\n");
            	printf("4.  Back\n");
            	scanf("%d",&choiceIN);
            	switch(choiceIN){
            		case 1:
            			kalkulasi(7);
            			break;
            		case 2:
            			kalkulasi(8);
            			break;
            		case 3:
            			kalkulasi(9);
            			break;
            		case 4:
            			system("cls");
            			break;
				}
				break;
            case 4:
            	kalkulasi(4);
                break;
            case 5:
                kalkulasi(5);
                break;
            case 6:
            	printf("\nBubble Sort:\n");
                printf("Bubble sort is a simple sorting algorithm that repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order.\n");
                printf("It passes through the list until no swaps are needed, which indicates that the list is sorted.\n");
                printf("In this program, we use bubble sort to rank students either by their names or by their final scores.\n");
                printf("Limitation for each value in this program is 0 - 100");
                break;
            case 7:
            	kalkulasi(7);
            	break;
            case 8:
            	kalkulasi(8);
            	break;
            case 9:
            	kalkulasi(9);
            	break;
            case 10:
            	printf("Exiting Program:\n");
            	break;
            default:
                printf("Invalid choice. Please enter a valid option.\n");
        }
    } while (choice != 10);
    return 0;
}
//Copy Paste input untuk test case dibawah   Anies 80 75 85 Prabowo 70 65 75 Ganjar 85 50 70 Teufik 60 55 70 Ryan 20 20 65
//TEST CASE
//Student 1:
//Name: Anies
//Nilai Tugas: 80
//Nilai UTS: 75
//Nilai UAS: 85

//Student 2:
//Name: Prabowo
//Nilai Tugas: 70
//Nilai UTS: 65
//Nilai UAS: 75

//Student 3:
//Name: Ganjar
//Nilai Tugas: 85
//Nilai UTS: 50
//Nilai UAS: 70

//Student 4:
//Name: Teufik
//Nilai Tugas: 60
//Nilai UTS: 55
//Nilai UAS: 70

//Student 5:
//Name: Ryan
//Nilai Tugas: 20
//Nilai UTS: 20
//Nilai UAS: 65

