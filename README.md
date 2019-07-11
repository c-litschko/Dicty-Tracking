# Dicty-Tracking
[![](https://img.shields.io/badge/DOI%3A-10.6084%2Fm9.figshare.5024552-blue.svg)](https://doi.org/10.6084/m9.figshare.5024552) [![](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/LICENSE)

---

#### Table of Contents
* [About](#about)
* [Tracking examples](#tracking-examples)
* [Video Tutorial](#video-tutorial)
* [Code](#code)
* [License](#license)
* [How to cite](#how-to-cite)
* [Dicty Tracking in the literature](#dicty-tracking-in-the-literature)

---

### About

**Dicty Tracking** is a MATLAB®-based standalone tool developed for semi-automatic tracking of migrating *Dictyostelium discoideum* cells from phase-contrast time-lapse image series. The tool requires [Fiji/ImageJ](https://imagej.net/Fiji) and the installation of [MATLAB Runtime](https://www.mathworks.com/products/compiler/mcr.html).

#### How it works
* **Cell detection**: using the Sobel operator implemented in MATLAB®’s Image Processing Toolbox as well as subsequent
dilation and erosion steps Dicty tracking is able to efficiently detect cell bodies of migrating *Dictyostelium* cells from phase-contrast images. The adjustment of several parameters affecting accuracy of cell body detection is possible and might be necessary in some cases.
* **Quality control and cell selection**: the accuracy of cell body detection can be checked by the user in Fiji/ImageJ. Afterwards, a graphical user interface (GUI) allows the selection of cells that should be tracked by the algorithm. Usually, some cells have to be excluded from analyses due to collision, division or because they leave the field of view.
* **Cell tracking and data export**: the Dicty Tracking algorithm tracks the selected cells by connecting the centroids of a cell at each time point of the image series. Dicty Tracking generates a .tif stack with differently colored cell tracks and saves the following parameters of each tracked cell at each time point into an Excel sheet:
  * x and y position
  * distance to previous point (step size)
  * overall track length
  * direct distance to the starting point
  * instantaneous velocity
  * instantaneous angle (angle between the displacement vector and the x-axis, see [**user guide**](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/Dicty-Tracking-User-Guide.pdf) for more details)
  * turning angle (difference of subsequent instantaneous angles)
  * the cosine of the turning angle.
* **Further analyses**: Dicty Tracking comes with additional VBA-based Excel workbooks allowing the calculation of
  * mean speed
  * directionality ratio
  * mean squared displacement (MSD).

A more detailed description of *Dictyostelium* cell tracking and subsequent migration analysis with Dicty Tracking is provided in the [**user guide**](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/Dicty-Tracking-User-Guide.pdf).

---

### Tracking examples

![alt text](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/demo-movies/demo-mov-unconfined.gif) <br />
Freely (unconfined) and randomly migrating Ax2 wild-type Dictyostelium cells tracked with Dicty Tracking

![alt text](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/demo-movies/demo-mov-confined.gif) <br />
Ax2 wild-type Dictyostelium cells confined by a 0.17 nm 1.5% agarose slice tracked with Dicty Tracking

---

### Video Tutorial

A short video tutorial (about 3 minutes) for Dicty Tracking is available at **[vimeo.com](https://vimeo.com/219859828)**.  
[![](http://i.imgur.com/aYCjlo7m.png?1)](https://vimeo.com/219859828 "Dicty Tracking Video Tutorial at vimeo.com - Click to Watch!")

---

### Code

The code behind Dicty Tracking is stored in the subrepository [source-code](https://github.com/ChristofLitschko/Dicty-Tracking/tree/master/source-code). Quick and direct access to the particular code files is possible via the following links:
* **MATLAB® code**
  * [Dicty_tracking_v1_3.m](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/source-code/Dicty_tracking_v1_3.m): cell body identification, centroid extraction, cell selection GUI, tracking, data export
* **VBA code of associated Excel workbooks**
  * [trajectories.vb](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/source-code/Dicty-Tracking-Evaluation/trajectories.vb): shifts the trajectories of all tracked cells to the origin (for generation of trajectory plots)
  * [speed.vb](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/source-code/Dicty-Tracking-Evaluation/speed.vb): calculates mean speed of all tracked cells of an image series
  * [dir ratio.vb](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/source-code/Dicty-Tracking-Evaluation/dir%20ratio.vb): 
calculates mean dir ratio of all tracked cells of an image series
  * [MSD preparation.vb](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/source-code/Dicty-Tracking-Evaluation/MSD%20preparation.vb): prepares tracking data for import into MSD calculation workbook
  * [MSD_1.vb](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/source-code/MSD-Calculation/MSD_1.vb), [MSD_2.vb](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/source-code/MSD-Calculation/MSD_2.vb), [MSD_3.vb](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/source-code/MSD-Calculation/MSD_3.vb) and [MSD_4.vb](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/source-code/MSD-Calculation/MSD_4.vb): allow calculation of mean squared displacement (MSD) at each time point for up to 4 different cell populations
  
---

### License

The tool and it's associated files including Excels workbooks, the user guide and sample movies are licensed under the [MIT license](LICENSE).

---

### How to cite

The Dicty Tracking fileset is also publically available on **[figshare](https://figshare.com/articles/Dicty_Tracking_A_standalone_tool_for_fast_and_easy_tracking_of_migrating_Dictyostelium_cells/5024552)**. It's attributed digital object identifier (DOI) is [10.6084/m9.figshare.5024552](https://doi.org/10.6084/m9.figshare.5024552). Dicty Tracking can be cited as

> Litschko C (2017) Dicty Tracking: A standalone tool for fast and easy tracking of migrating Dictyostelium cells. figshare. https://doi.org/10.6084/m9.figshare.5024552

---

### Dicty Tracking in the literature

Dicty Tracking  and/or associated files were used in the following research papers:
* Litschko C, Brühmann S, Csiszár A, Stephan T, Dimchev V, Damiano-Guercio J, Junemann A, Körber S, Winterhoff M, Nordholz B, Ramalingam N, Peckham M, Rottner K, Merkel R, Faix J. (2019) Functional integrity of the contractile actin cortex is safeguarded by multiple Diaphanous-related formins. *Proc Natl Acad Sci U S A* 116(9):3594-3603. https://doi.org/10.1073/pnas.1821638116
* Litschko C, Linkner J, Brühmann S, Stradal TEB, Reinl T, Jänsch L, Rottner K, Faix J. (2017) Differential functions of WAVE regulatory complex subunits in the regulation of actin-driven processes. *Eur J Cell Biol.* 96(8):715-727. https://doi.org/10.1016/j.ejcb.2017.08.003
* Latham SL, Ehmke N, Reinke PYA, Taft MH, Eicke D, Reindl T, Stenzel W, Lyons MJ, Friez MJ, Lee JA, Hecker R, Frühwald MC, Becker K, Neuhann TM, Horn D, Schrock E, Niehaus I, Sarnow K, Grützmann K, Gawehn L, Klink B, Rump A, Chaponnier C, Figueiredo C, Knöfler R, Manstein DJ, Di Donato N (2018) Variants in exons 5 and 6 of ACTB cause syndromic thrombocytopenia. *Nat Commun.* 9(1):4250. https://doi.org/10.1038/s41467-018-06713-0
