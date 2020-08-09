
#!/bin/sh

curPath=$(readlink -f "$(dirname "$0")")
cd $curPath
cd ..

git fetch origin

git pull origin master