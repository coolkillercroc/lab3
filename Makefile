all: ctags
	mcs Program.cs

.PHONY: clean
clean:
	rm -f Program.exe TAGS

.PHONY: ctags
ctags: clean
	ctags -e -R .
