;#DropDB TimeLimitedEasyTest

#Application TimeLimitedWin
#Application TimeLimitedWeb

*Action Navigation(User)

*ProcessRecord
 Full Name = ''

#IfDef TimeLimitedWeb
*Action Edit
#EndIf
 
*FillForm
 Full Name = Test User
 
*Action Cancel

#IfDef TimeLimitedWin
*HandleDialog
 Respond = Yes
#EndIf

*CheckFieldValues
 Full Name = ''
