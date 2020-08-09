#!/bin/sh

curPath=$(readlink -f "$(dirname "$0")")
echo $curPath

Unity_Path="C:/Program Files/Unity/Hub/Editor/2018.4.23f1/Editor/Unity.exe"
Project_Path="E:/Workspace/Auto"
Log_Path="${curPath}/BuildLog.log"
Execete_Method="EditorTest.Build"
Build_Path="${curPath}/Build/AutoBuildBySh"


"$Unity_Path" -projectPath $Project_Path -logFile $Log_Path -nographics -quit -batchmode -executeMethod $Execete_Method -buildPath $Build_Path &
sleep 6

echo "开始读取Log"

# cat $Log_Path

tail --pid=$! -f $Log_Path