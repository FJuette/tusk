#!/bin/bash
OLDNAME='Tusk'
NEWNAME='Riki'
rm -Rf ./../$NEWNAME
cp -rf ./../$OLDNAME ./../$NEWNAME
cd ./../$NEWNAME
rm -Rf .git
rm -Rf ./src/$OLDNAME.Common/obj
rm -Rf ./src/$OLDNAME.Common/bin
rm -Rf ./src/$OLDNAME.Api/obj
rm -Rf ./src/$OLDNAME.Api/bin
rm -Rf ./src/$OLDNAME.Persistence/obj
rm -Rf ./src/$OLDNAME.Persistence/bin
rm -Rf ./src/$OLDNAME.Domain/obj
rm -Rf ./src/$OLDNAME.Domain/bin
rm -Rf ./src/$OLDNAME.Application/obj
rm -Rf ./src/$OLDNAME.Application/bin
rm -Rf ./src/$OLDNAME.Infrastructure/obj
rm -Rf ./src/$OLDNAME.Infrastructure/bin
find . -type d -name '*'$OLDNAME'*' -print0 | xargs -0 -n1 bash -c 'mv "$0" "${0/'$OLDNAME'/'$NEWNAME}'"';
find . -type f -name '*'$OLDNAME'*' -print0 | xargs -0 -n1 bash -c 'mv "$0" "${0/'$OLDNAME'/'$NEWNAME}'"'
find . -type f -name '*' -exec sed -i "" 's/'$OLDNAME'/'$NEWNAME'/g' {} +