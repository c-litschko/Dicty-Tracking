Sub MSD_3()
Dim track As Double
Dim row As Double
Dim frame As Double
'frames = # of frames per track
frames = Worksheets("Zwischenwerte").Cells(5, 8).Value
'tracks = # of tracks
tracks = Worksheets("Zwischenwerte").Cells(3, 8).Value

Worksheets("Zwischenwerte_3").Cells.Delete

For track = 1 To tracks
    For frame = 1 To frames
        'calculate rownumbers for x and y @ timepoint/frame t0 (termed rownumt0)
        rownumt0 = frames * (track - 1) + 1 + 1
        'calculate rownumber for x and y @ a given timepoint/frame t (termed rownumt)
        rownumt = frames * (track - 1) + frame + 1
        'get values of x and y @ t0 and t
        x0 = Worksheets("MSD_3").Cells(rownumt0, 2).Value
        xt = Worksheets("MSD_3").Cells(rownumt, 2).Value
        y0 = Worksheets("MSD_3").Cells(rownumt0, 3).Value
        yt = Worksheets("MSD_3").Cells(rownumt, 3).Value
        'calculate (xt-x0)^2 and (yt-y0)^2
        Worksheets("Zwischenwerte_3").Cells(rownumt, 2) = (xt - x0) ^ 2
        Worksheets("Zwischenwerte_3").Cells(rownumt, 3) = (yt - y0) ^ 2
        'add column labels and time
        Worksheets("Zwischenwerte_3").Cells(1, 1) = "t"
        Worksheets("Zwischenwerte_3").Cells(1, 2) = "x^2 [µm^2]"
        Worksheets("Zwischenwerte_3").Cells(1, 3) = "y^2 [µm^2]"
        Worksheets("Zwischenwerte_3").Cells(1, 4) = "x^2 + y^2"
        Worksheets("Zwischenwerte_3").Cells(1, 5) = "MSD [µm^2]"
        Worksheets("Zwischenwerte_3").Cells(rownumt, 1) = Worksheets("MSD_3").Cells(rownumt, 1).Value
        'calculate sum of (xt-x0)^2 and (yt-y0)^2 @ timepoint t
        Worksheets("Zwischenwerte_3").Cells(rownumt, 4) = (xt - x0) ^ 2 + (yt - y0) ^ 2
        'calculate MSD for given cell @ given timepoint
        Sum = WorksheetFunction.Sum(Range(Worksheets("Zwischenwerte_3").Cells(frames * (track - 1) + 1 + 1, 4), Worksheets("Zwischenwerte_3").Cells(rownumt, 4)))
        MSD = Sum / frame
        Worksheets("Zwischenwerte_3").Cells(rownumt, 5) = MSD
    Next frame
Next track

'sort calculated MSD by time
For frame = 1 To frames
    Worksheets("Zwischenwerte_3").Cells(1, frame + 6) = frame
    For track = 1 To tracks
    Worksheets("Zwischenwerte_3").Cells(track + 1, frame + 6) = Worksheets("Zwischenwerte_3").Cells(frames * (track - 1) + frame - 1 + 2, 5)
    Next track
Next frame

For frame = 1 To frames
    'calculate average and sd of MSD at each timepoint
    mean = WorksheetFunction.Average(Range(Worksheets("Zwischenwerte_3").Cells(2, frame + 6), Worksheets("Zwischenwerte_3").Cells(tracks + 1, frame + 6)))
    sd = WorksheetFunction.StDev(Range(Worksheets("Zwischenwerte_3").Cells(2, frame + 6), Worksheets("Zwischenwerte_3").Cells(tracks + 1, frame + 6)))
    'round mean
    mean_r = Round(mean, 3)
    'calculate and round S.E.M.
    sem = sd / (tracks ^ (1 / 2))
    sem_r = Round(sem, 3)
    'add time and data to MSD worksheet
    timeint = Worksheets("Zwischenwerte").Cells(4, 8)
    Worksheets("MSD_3").Cells(frame + 1, 7) = timeint * (frame - 1)
    Worksheets("MSD_3").Cells(frame + 1, 8) = mean_r
    Worksheets("MSD_3").Cells(frame + 1, 9) = sem_r
    'add column labels to MSD worksheet
    Worksheets("MSD_3").Cells(1, 7) = "t [ ]"
    Worksheets("MSD_3").Cells(1, 8) = "MSD"
    Worksheets("MSD_3").Cells(1, 9) = "S.E.M."
Next frame



End Sub
