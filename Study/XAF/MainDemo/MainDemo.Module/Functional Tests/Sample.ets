;#DropDB MainDemoEasyTest

#Application MainDemoWin
#Application MainDemoWeb

*Action Navigation(User)

*ProcessRecord
 Full Name = ''

#IfDef MainDemoWeb
*Action Edit
#EndIf
 
*FillForm
 Full Name = Test User
 
*Action Cancel

#IfDef MainDemoWin
*HandleDialog
 Respond = Yes
#EndIf

*CheckFieldValues
 Full Name = ''
