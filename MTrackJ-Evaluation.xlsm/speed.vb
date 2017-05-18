Sub speed()
Dim track As Double
Dim row As Double
Dim frame As Double
Dim speedfactor As Double
Dim newunit As String
lastval = Worksheets("Zwischenwerte").Cells(2, 2).Value 'last time point
lastrow = Worksheets("Zwischenwerte").Cells(3, 2).Value

Worksheets("Zwischenwertespeed").Cells.Delete

'ask user if speed unit has to be changed or not and apply changes
speedfactor = InputBox("Do you want to change the unit of the speed parameter? - Please type in a value as conversion factor (e.g. 60 for changing µm/sec to µm/min) or simply '1' for no change. Thanks!", "change speed unit?")
If speedfactor <> 1 Then
newunit = InputBox("Please type in the designation of the new speed unit. Thanks!", "new speed unit designation")
Worksheets("speed").Cells(1, 3) = "v [" & newunit & "]"
End If

'sort speed values by time/frame into worksheet "Zwischenwertespeed"
For track = 1 To Worksheets("Zwischenwerte").Cells(1, 2).Value
    For frame = 2 To Worksheets("Zwischenwerte").Cells(2, 2).Value
        Worksheets("Zwischenwertespeed").Cells(1, frame - 1) = frame
        Worksheets("Zwischenwertespeed").Cells(track + 1, frame - 1) = Worksheets("MTrackJ-Points").Cells(frame + 1 + lastval * (track - 1), 12) * speedfactor
    Next frame
Next track

'write time and frame into columns A and B, resp. and calculate temporal average and StDev of speed (columns C and D)
tracknum = Worksheets("Zwischenwerte").Cells(1, 2).Value
For frame = 2 To Worksheets("Zwischenwerte").Cells(2, 2).Value
    speedvals = Worksheets("Zwischenwertespeed").Range(Worksheets("Zwischenwertespeed").Cells(2, frame - 1), Worksheets("Zwischenwertespeed").Cells(tracknum + 1, frame - 1))
    Worksheets("speed").Cells(frame, 1) = frame
    Worksheets("speed").Cells(frame, 2) = Worksheets("MTrackJ-Points").Cells(frame + 1, 6)
    Worksheets("speed").Cells(frame, 3) = Round(WorksheetFunction.Average(speedvals), 3)
    Worksheets("speed").Cells(frame, 4) = Round(WorksheetFunction.StDev(speedvals), 3)
Next frame

Worksheets("Zwischenwertespeed").Cells.Delete

'sort speed values by track into worksheet "Zwischenwertespeed"
For track = 1 To Worksheets("Zwischenwerte").Cells(1, 2).Value
    Worksheets("Zwischenwertespeed").Cells(1, track) = track
    For frame = 2 To Worksheets("Zwischenwerte").Cells(2, 2).Value
        Worksheets("Zwischenwertespeed").Cells(frame, track) = Worksheets("MTrackJ-Points").Cells(frame + 1 + lastval * (track - 1), 12) * speedfactor
    Next frame
Next track

'write track into column X and calculate speed average and StDev of each cell/track (column G,H)
framenum = Worksheets("Zwischenwerte").Cells(2, 2).Value
For track = 1 To Worksheets("Zwischenwerte").Cells(1, 2).Value
    speedvals2 = Worksheets("Zwischenwertespeed").Range(Worksheets("Zwischenwertespeed").Cells(2, track), Worksheets("Zwischenwertespeed").Cells(framenum, track))
    Worksheets("speed").Cells(track + 1, 6) = track
    Worksheets("speed").Cells(track + 1, 7) = Round(WorksheetFunction.Average(speedvals2), 3)
    Worksheets("speed").Cells(track + 1, 8) = Round(WorksheetFunction.StDev(speedvals2), 3)
    
Next track

Worksheets("Zwischenwertespeed").Cells.Delete

'calculate overall dir ratio average from and StDev from track averages
speedvals3 = Worksheets("speed").Range(Worksheets("speed").Cells(2, 7), Worksheets("speed").Cells(tracknum, 7))
Worksheets("speed").Cells(2, 10) = Round(WorksheetFunction.Average(speedvals3), 3)
Worksheets("speed").Cells(2, 11) = Round(WorksheetFunction.StDev(speedvals3), 3)

End Sub
