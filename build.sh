nasm -f elf32 src/kernel/boot.asm -o boot.o
clang --target=i386-elf -c src/kernel/kernel.c -o kernel.o
x86_64-elf-ld -m elf_i386 -T src/kernel/linker.ld -o CDROOT/kernel/kernel.bin boot.o kernel.o
rm -f boot.o kernel.o

xorriso -as mkisofs -b boot/limine-bios-cd.bin \
        -no-emul-boot -boot-load-size 4 -boot-info-table \
        --efi-boot boot/limine-uefi-cd.bin \
        -efi-boot-part --efi-boot-image --protective-msdos-label \
        CDROOT -o ISO/ZoneOS.iso

cd ISO

./limine bios-install ZoneOS.iso

cd ..

qemu-system-x86_64 -cdrom ISO/ZoneOS.iso