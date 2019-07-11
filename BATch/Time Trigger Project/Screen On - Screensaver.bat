@echo off
powercfg /x monitor-timeout-ac 0
reg add "HKEY_CURRENT_USER\Control Panel\Desktop" /f /v ScreenSaveActive /t REG_SZ /d 1