;#DropDB AIS2011EasyTest

#Application AIS2011Win
#Application AIS2011Web

*Action Navigation(User)

*ProcessRecord
 Full Name = ''

#IfDef AIS2011Web
*Action Edit
#EndIf
 
*FillForm
 Full Name = Test User
 
*Action Cancel

#IfDef AIS2011Win
*HandleDialog
 Respond = Yes
#EndIf

*CheckFieldValues
 Full Name = ''
