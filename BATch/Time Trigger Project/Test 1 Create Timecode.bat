@echo off
For /f "usebackq tokens=1,2,3,4 delims=:. " %%a in ('%time%') Do (
      set hh=00%%a
      set mm=00%%b
      set ss=00%%c
      set hs=00%%d
  )
call :Print
   set hh=%hh:~-2%
   set mm=%mm:~-2%
   set ss=%ss:~-2%
   set hs=%hs:~-2%
call :Print
   set /a hh=((%hh:~0,1% * 10) + %hh:~1,1%) * 60 * 60 * 100
   set /a mm=((%mm:~0,1% * 10) + %mm:~1,1%) * 60 * 100
   set /a ss=((%ss:~0,1% * 10) + %ss:~1,1%) * 100
   set /a hs=((%hs:~0,1% * 10) + %hs:~1,1%)
call :Print
   set /a _timecode=hh + mm + ss + hs

echo %_timecode%
pause
exit

:Print
  echo Hours       %hh%
  echo Minutes     %mm%
  echo Seconds     %ss%
  echo h-Seconds   %hs%
  pause
  echo.
goto :EOF



set lol=asdf
exit /b