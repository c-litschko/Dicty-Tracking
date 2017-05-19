Sub MSD()
Dim track As Double
Dim row As Double
Dim frame As Double
lastval = Worksheets("Zwischenwerte").Cells(2, 2).Value
lastrow = Worksheets("Zwischenwerte").Cells(3, 2).Value


'write track, frame and time to worksheet "dir ratio" (columns A, B, C)
For row = 1 To Worksheets("Zwischenwerte").Cells(3, 2).Value
    Worksheets("MSD").Cells(row + 1, 1) = Worksheets("MTrackJ-Points").Cells(row + 1, 2)
    Worksheets("MSD").Cells(row + 1, 2) = Worksheets("MTrackJ-Points").Cells(row + 1, 3)
    Worksheets("MSD").Cells(row + 1, 3) = Worksheets("MTrackJ-Points").Cells(row + 1, 6)
    Worksheets("MSD").Cells(row + 1, 4) = Worksheets("MTrackJ-Points").Cells(row + 1, 4)
    Worksheets("MSD").Cells(row + 1, 5) = Worksheets("MTrackJ-Points").Cells(row + 1, 5)
Next row

End Sub
