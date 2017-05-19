Sub directionalityratio()
Dim track As Double
Dim row As Double
Dim frame As Double
lastval = Worksheets("Zwischenwerte").Cells(2, 2).Value
lastrow = Worksheets("Zwischenwerte").Cells(3, 2).Value

Worksheets("Zwischenwertedir").Cells.Delete

'write track, frame and time to worksheet "dir ratio" (columns A, B, C)
For row = 1 To Worksheets("Zwischenwerte").Cells(3, 2).Value
    Worksheets("dir ratio").Cells(row + 1, 1) = Worksheets("MTrackJ-Points").Cells(row + 1, 2)
    Worksheets("dir ratio").Cells(row + 1, 2) = Worksheets("MTrackJ-Points").Cells(row + 1, 3)
    Worksheets("dir ratio").Cells(row + 1, 3) = Worksheets("MTrackJ-Points").Cells(row + 1, 6)
Next row

'calculate directionality ratio for each timepoint of each track (column D)
For track = 1 To Worksheets("Zwischenwerte").Cells(1, 2).Value
    For frame = 2 To Worksheets("Zwischenwerte").Cells(2, 2).Value
        rownum = lastval * (track - 1) + frame + 1
        D2S = Worksheets("MTrackJ-Points").Cells(rownum, 9)
        Leng = Worksheets("MTrackJ-Points").Cells(rownum, 8)
        If D2S = 0 Then
        'if cell does not move (D2S = 0) do not calculate dir ratio
        Else
        Worksheets("dir ratio").Cells(rownum, 4) = Round(D2S / Leng, 3)
        End If
    Next frame
Next track

'sort dir ratio values by time/frame into worksheet "Zwischenwertedir"
For track = 1 To Worksheets("Zwischenwerte").Cells(1, 2).Value
    For frame = 2 To Worksheets("Zwischenwerte").Cells(2, 2).Value
        Worksheets("Zwischenwertedir").Cells(1, frame - 1) = frame
        Worksheets("Zwischenwertedir").Cells(track + 1, frame - 1) = Worksheets("dir ratio").Cells(frame + 1 + lastval * (track - 1), 4)
    Next frame
Next track

'write time and frame into columns F and G, resp. and calculate temporal average and StDev of dir ratio (columns H and I)
tracknum = Worksheets("Zwischenwerte").Cells(1, 2).Value
For frame = 2 To Worksheets("Zwischenwerte").Cells(2, 2).Value
    dirvals = Worksheets("Zwischenwertedir").Range(Worksheets("Zwischenwertedir").Cells(2, frame - 1), Worksheets("Zwischenwertedir").Cells(tracknum + 1, frame - 1))
    Worksheets("dir ratio").Cells(frame, 6) = frame
    Worksheets("dir ratio").Cells(frame, 7) = Worksheets("dir ratio").Cells(frame + 1, 3)
    Worksheets("dir ratio").Cells(frame, 8) = Round(WorksheetFunction.Average(dirvals), 3)
    Worksheets("dir ratio").Cells(frame, 9) = Round(WorksheetFunction.StDev(dirvals), 3)
Next frame

Worksheets("Zwischenwertedir").Cells.Delete

'sort dir ratio values by track into worksheet "Zwischenwertedir"
For track = 1 To Worksheets("Zwischenwerte").Cells(1, 2).Value
    Worksheets("Zwischenwertedir").Cells(1, track) = track
    For frame = 2 To Worksheets("Zwischenwerte").Cells(2, 2).Value
        Worksheets("Zwischenwertedir").Cells(frame, track) = Worksheets("dir ratio").Cells(frame + 1 + lastval * (track - 1), 4)
    Next frame
Next track

'write track into column X and calculate dir ratio average and StDev of each cell/track (column L,M)
framenum = Worksheets("Zwischenwerte").Cells(2, 2).Value
For track = 1 To Worksheets("Zwischenwerte").Cells(1, 2).Value
    dirvals2 = Worksheets("Zwischenwertedir").Range(Worksheets("Zwischenwertedir").Cells(2, track), Worksheets("Zwischenwertedir").Cells(framenum, track))
    Worksheets("dir ratio").Cells(track + 1, 11) = track
    Worksheets("dir ratio").Cells(track + 1, 12) = Round(WorksheetFunction.Average(dirvals2), 3)
    Worksheets("dir ratio").Cells(track + 1, 13) = Round(WorksheetFunction.StDev(dirvals2), 3)
Next track

Worksheets("Zwischenwertedir").Cells.Delete

'calculate overall dir ratio average from and StDev from track averages
dirvals3 = Worksheets("dir ratio").Range(Worksheets("dir ratio").Cells(2, 12), Worksheets("dir ratio").Cells(tracknum, 12))
Worksheets("dir ratio").Cells(2, 15) = Round(WorksheetFunction.Average(dirvals3), 3)
Worksheets("dir ratio").Cells(2, 16) = Round(WorksheetFunction.StDev(dirvals3), 3)

End Sub
