Sub trajectories()
Dim track As Single
lastval = Worksheets("Zwischenwerte").Cells(2, 2).Value
For track = 1 To Worksheets("Zwischenwerte").Cells(1, 2).Value
    Dim frame As Single
    For frame = 1 To Worksheets("Zwischenwerte").Cells(2, 2).Value
    'for x
    Worksheets("trajectories").Cells(frame + 2, track * 2 - 1) = Worksheets("MTrackJ-Points").Cells(lastval * (track - 1) + (lastval - (lastval - frame)) + 1, 4) - Worksheets("MTrackJ-Points").Cells(lastval * (track - 1) + (lastval - (lastval - 1)) + 1, 4)
    Worksheets("trajectories").Cells(2, track * 2 - 1) = "x"
    Worksheets("trajectories").Cells(1, track * 2 - 1) = track
    'for y
    Worksheets("trajectories").Cells(frame + 2, track * 2) = Worksheets("MTrackJ-Points").Cells(lastval * (track - 1) + (lastval - (lastval - frame)) + 1, 5) - Worksheets("MTrackJ-Points").Cells(lastval * (track - 1) + (lastval - (lastval - 1)) + 1, 5)
    Worksheets("trajectories").Cells(2, track * 2) = "y"
    Worksheets("trajectories").Cells(1, track * 2) = track
    Next frame
Next track
End Sub
