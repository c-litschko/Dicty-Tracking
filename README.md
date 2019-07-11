# Dicty-Tracking
[![](https://img.shields.io/badge/DOI%3A-10.6084%2Fm9.figshare.5024552-blue.svg)](https://doi.org/10.6084/m9.figshare.5024552) [![](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/LICENSE)

---

### About

Dicty Tracking is a MATLAB®-based standalone tool developed for semi-automatic tracking of migrating *Dictyostelium* cells from phase-contrast time-lapse image series. The tool requires [Fiji/ImageJ](https://imagej.net/Fiji) and the installation of [MATLAB Runtime](https://www.mathworks.com/products/compiler/mcr.html).

* **Cell detection**: using the Sobel operator implemented in MATLAB®’s Image Processing Toolbox as well as subsequent
dilation and erosion steps Dicty tracking is able to efficiently detect cell bodies of migrating *Dictyostelium* cells from phase-contrast images. The adjustment of several parameters affecting accuracy of cell body detection is possible and might be necessary in some cases.
* **Quality control and cell selection**: the accuracy of cell body detection can be checked by the user in Fiji/ImageJ. Afterwards, a graphical user interface (GUI) allows the selection of cells that should be tracked by the algorithm. Usually, some cells have to be excluded from analyses due to collision, division or because they leave the field of view.
3. **Cell tracking and data export**: the Dicty Tracking algorithm tracks the selected cells by connecting the centroids of a cell at each time point of the image series. Dicty Tracking generates a .tif stack with differently colored cell tracks and saves the following parameters at eacht time point into an Excel sheet:
  * Test

Dicty tracking is provided as a .zip package containing additional VBA-based Excel workbooks for further analyses 

The tool and it's associated files are licensed under the [MIT license](LICENSE). It is provided as a .zip package containing sample image series and additional Excel workbooks for further analysis. The complete fileset is publically available on **[figshare](https://figshare.com/articles/Dicty_Tracking_A_standalone_tool_for_fast_and_easy_tracking_of_migrating_Dictyostelium_cells/5024552)** and can be cited as:

*Litschko C (2017) Dicty Tracking: A standalone tool for fast and easy tracking of migrating Dictyostelium cells. figshare. https://doi.org/10.6084/m9.figshare.5024552*

See the [user guide](https://github.com/ChristofLitschko/Dicty-Tracking/blob/master/Dicty-Tracking-User-Guide.pdf) for more information.

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

### Dicty Tracking in the literature

Dicty Tracking  and/or associated files were used in the following research papers:
* Litschko C, Brühmann S, Csiszár A, Stephan T, Dimchev V, Damiano-Guercio J, Junemann A, Körber S, Winterhoff M, Nordholz B, Ramalingam N, Peckham M, Rottner K, Merkel R, Faix J. (2019) Functional integrity of the contractile actin cortex is safeguarded by multiple Diaphanous-related formins. *Proc Natl Acad Sci U S A* 116(9):3594-3603. https://doi.org/10.1073/pnas.1821638116
* Litschko C, Linkner J, Brühmann S, Stradal TEB, Reinl T, Jänsch L, Rottner K, Faix J. (2017) Differential functions of WAVE regulatory complex subunits in the regulation of actin-driven processes. *Eur J Cell Biol.* 96(8):715-727. https://doi.org/10.1016/j.ejcb.2017.08.003
