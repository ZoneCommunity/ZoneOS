bits 32	
section .text
	align 4
	dd 0x1BADB002
	dd 0x00
	dd - (0x1BADB002 + 0x00)
global start

GDT: 
	; null descriptor
	dd 0                
	dd 0 
	
	; code descriptor
	dw 0xFFFF           ; limit low
	dw 0                ; base low
	db 0                ; base middle
	db 10011010b        ; access
	db 11001111b        ; granularity
	db 0                ; base high
	
	; data descriptor
	dw 0xFFFF           ; limit low (Same as code)10:56 AM 7/8/2007
	dw 0                ; base low
	db 0                ; base middle
	db 10010010b        ; access
	db 11001111b        ; granularity
	db 0                ; base high
END_GDT:

; GDT Pointer
GDT_PTR: 
	dw END_GDT - GDT - 1 	; limit (Size of GDT)
	dd GDT 			; base of GDT
	
; Location of entries in GDT
CODE_SEG equ 0x08
DATA_SEG equ 0x10

extern kernel_main
start:
	lgdt [GDT_PTR] ; Install GDT
	jmp CODE_SEG:kernel

kernel:
	cli
	call kernel_main
	hlt