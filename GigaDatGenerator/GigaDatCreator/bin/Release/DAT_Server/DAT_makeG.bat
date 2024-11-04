@Echo Off
@set P1=%1
@if DEFINED P1 @Goto Start
@Echo Description: Make a G-DAT file 
@Echo              Convert a 'scncfg' file from 123Scan into a DAT file and 
@Echo              'combine' it with the firmware DAT file.
@Echo .
@Echo Method: .scncfg .dal HxxxxXxx-xxx-Xxx.dat+CxxxxXxx-xxx-Xxx GxxxxXxx-xxx-Xxx
@Echo .
@Echo Syntax: MakeG-DAT.bat [InScnCfgFile][InDatFile]            [EC] [DV] [HC]
@Echo Ex #1:  MakeG-DAT.BAT test.scncfg   CAADGS00-000-N14D0.DAT 1234 2192 0015
@Echo Ex #2:  MakeG-DAT.BAT test.scncfg   SAADGS00-000-N14D0.DAT 1234 2192 0015
@Echo .
@Echo Copyright: Zebra Technologies, 2016 
@Echo .
@Echo Release Notes:
@Echo   1.00:7/29/2016: Initial release
@Echo   1.01:8/07/2016: Better variable passing
@Goto Complete
  
:Start
@if exist log.txt           @del log.txt

@Rem Remove old environment vars
@Set CRN=
@set InScnCfgFile=
@Set InDatFile=
@Set ECLEV=
@Set SC=
@Set DV=
@Set HC=
@set BLK_SIZE=
@set PAD_CHAR=
@Set HW_REV=
@Set TOOLSDIR=tools

@Set PID=
@Set SCRN=
@Set TLRN=
@Set OutHDalFile=
@Set OutHDatFile=
@Set OutGDatFile=

@Rem Required Inputs
@set InScnCfgFile=%1
@Set InDatFile=%2
@Set ECLEV=%3
@Set DV=%4
@Set HC=%5

@Rem Optional Inputs
@set BLK_SIZE=%6
@set PAD_CHAR=%7
@set HW_REV=%8
@if NOT DEFINED BLK_SIZE    @set BLK_SIZE=2048
@if NOT DEFINED PAD_CHAR    @set PAD_CHAR=255
@if NOT DEFINED HW_REV      @Set HW_REV=0

@Rem Derived names
@Set SC=0248
@Set PID=%DV%
@Set CRN=%InDatFile:~1,15%
@Set SCRN=H%CRN%
@Set TLRN=C%CRN%
@Set TLRN1=G%CRN%
@Set OutHDalFile=%SCRN%L%InDatFile:~17,1%.DAL
@Set OutHDatFile=%SCRN%%InDatFile:~16,2%.DAT
@Set OutGDatFile=%TLRN1%%InDatFile:~16,2%.DAT

@Rem Delete old derived files
@if exist %OutHDalFile%     @del %OutHDalFile%
@if exist %OutHDatFile%     @del %OutHDatFile%
@if exist %OutGDatFile%     @del %OutGDatFile%

@Rem 1. Convert 'scncfg' file into 'dal' file
@%TOOLSDIR%\scncfg2dal.exe %InScnCfgFile% %OutHDalFile% %BLK_SIZE% %PAD_CHAR%
@if not exist %OutHDalFile% @Echo Failed:scncfg2dal.exe
@if not exist %OutHDalFile% @Goto Fail
@Rem pause

@Rem 2. Convert 'dal' file into 'dat' file
@Echo DAT-Gen:Rev-1.29:Zebra Tech, 2016
@%TOOLSDIR%\Dat_Gen.exe -H %PID% %ECLEV% -S -V 4 %DV% %HC% %SC% %SCRN% %TLRN% %HW_REV% %OutHDalFile% -ignoreRelString -O %OutHDatFile% 
@if not exist %OutHDatFile% @Echo Failed:Dat_Gen.exe
@if not exist %OutHDatFile% @Goto Fail
@Rem pause

@Rem 3. Combine 'scncfg DAT' file with 'firmware DAT' file into 'G-DAT' file
@%TOOLSDIR%\DAT-Combiner.exe -H %DV% %ECLEV% %TLRN% -S %OutHDatFile% -S %InDatFile% -O %OutGDatFile% 
@if not exist %OutGDatFile% @Echo Failed:DAT-Combiner.exe
@if not exist %OutGDatFile% @Goto Fail
@Rem pause

@Goto Pass

:Fail
@Echo . >>log.txt
@Echo Fail:Process failed >>log.txt
@Echo . >>log.txt
@Goto Done

:Pass
@Echo .
@Echo Pass:Process complete >>log.txt
@Echo Input: %InScnCfgFile% %InDatFile% EC=%ECLEV% DV=%DV% HC=%HC% BlkSize=%BLK_SIZE% Pad=%PAD_CHAR% HWREV=%HW_REV% >>log.txt
@if exist %OutHDalFile%    @Echo Created file %OutHDalFile% >>log.txt
@if exist %OutHDatFile%    @Echo Created file %OutHDatFile% >>log.txt
@if exist %OutGDatFile%    @Echo Created file %OutGDatFile% >>log.txt
@if exist %OutGDatFile%    %TOOLSDIR%\checksum.exe %OutGDatFile% | find "sum =" >>log.txt
@Echo . >>log.txt
:Done
@Goto Complete

:Complete
@Type log.txt
@Echo On

pause

