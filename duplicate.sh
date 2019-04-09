#!/bin/bash
NEWNAME="Riki"
cp ./../tusk ./../$NEWNAME
cd ./../$NEWNAME
find . -type f -name '*' -exec sed -i 's/Tusk/${NEWNAME}/g' {} +