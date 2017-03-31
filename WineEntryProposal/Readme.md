***Installation***

In order to run this application, you must have JavaScript enabled in your browser, download, compile, and run the solution
from Visual Studio.  The solution does utilize Entity Framework, and also makes use of jQuery.

***Brief Synposis***

My Code Louisville .NET/c# Project is a web app designed to allow wineries to track inventories of wines.  It allows
for storage of information such as wine brand name, american viticultural area, alcohol by volume, ttb wine class, wine
type (like table wine or dessert wine), bottle volume, unit of measure, it also keeps information on varietals as objects
including but not limited to a picture of the varietal.  The varietal information has varietal family such as Vitis 
Vinifera, cold hardiness zone, and other information.  A user can presently add a wine or delete a wine from the database
of wines.  The add a wine or view inventory buttons are visible from the Home page of the application.  When the application 
first loads, the user may not see the slider that is present on the home page, however, it is assuredly there. To try out
a wine with a picture for the varietal, try a wine that has a URL that is seeded in the dB (e.g.  Concord).

First, for testing purposes, Add a wine, view inventory, delete a wine, check out all of the other pages.  I set up an 
under construction view for the Vendors and Customers pages to allow users to know that those pages are not quite ready.

There is a known issue that the email script or XML file is not presently working.  It is being addressed.  

The navigation buttons on the slider on the home page say First Wine and Next Wine, but the user may or may not load wine
images while testing in the slider.  The slider was built as an extra portion add-on for this project.  A secondary database called 
MediaContext has been added on for an Admin panel that will be added later to this application.  To test out the cool slider, go
to the following URL.  I did not include a link to this purposefully (with intention) in the solution.

~Slider/Index

On this page, it will be possible to add images, delete images, add wines, or view inventory.  Images must be 800 x 365 pixels.
There is another known issue of sizing regarding filesize with images here using the filestream method.  

Synopsis and Motivation:

Grateful Goat Wine Inventory Management System

A Solution For Ever Changing Needs In the Industries Administered By Local, State, and Federal
ATC, ABC, Liquor Control Boards, and the Federal Tax and Trade Bureau (TTB).

This project represents a love not only for the craft and trade of the manufacture and sale of alcohol 
and libations/craft beverage, but also a love for creativity in and of itself.  
Expressionism is an art form that is lost in today’s world.  Grateful Goat Vineyard & Winery came about 
initially from a love of the owners’ John and Lindsay Fouts of the romanticism that surrounded grapes, 
vineyards, and wines.  John and Lindsay lusted toward the idea of owning a winery.

After doing everything it took (putting the business plan together, securing SBA funding, gaining solid 
and awesome knowledge in the fields of viticulture and enology, never-ever stopping working during 
waking hours for many years, and much, much more); and all before the age of 40, both deserve a well-earned 
reprieve to see the ‘the fruits of their labors’.  The vineyard and winery work was overwhelmingly and 
exceedingly time consuming and engulfed every aspect of the couple’s lives. When the winery work started, 
both John and Lindsay were both working full time as well.  John and Lindsay also taught in addition to 
their jobs and the winery as well part time.  Later, John had a spine surgery that forever changed his 
life, in which he was permanently injured.  It was a that time that things began to change.

To make a long story shorter, this app is part of an evolution that occurred due to that surgery and medical 
malpractice.  It goes back to that clichéd adage, ‘when life gives you lemons, make lemonade…or in this case, 
perhaps, lemon wine…or maybe not’.  That might make one have a sour face, and sour faces aren’t good for business.  

Tartness is an important component for wine.  Acidity is something that is necessary for good mouthfeel and a 
well-balanced wine.  Grapes are a fruit that have the perfect balance of sugars and acids that make them perfect 
for making wine without any adjustments prior to fermentation.

So as a former winery owner (Grateful Goat Vineyard & Winery is now closed due to John’s health and the 
malpractice that occurred), John has plenty of experience in dealing with customer needs, employee needs, 
server needs, field worker needs, harvest needs, distribution needs, customer needs, and winemaker needs.  
As one of the smaller wineries in the state of Indiana, John and Lindsay had to wear all of the hats for the 
business when they got started, and so have a unique perspective on outlook and needs of these groups or 
stakeholders/users of the app.  John hopes that this app brings joy to your day.  

Please note:  This is only phase I of app development, and the app is far from complete.


***API Reference***

Project so small, not currently needed.

***Tests***

Self explanatory - tests so simple.  As project grows, tests to be added.

***Contributors***

John R. Fouts (thank you to the folks at <codelouisville> for helping teach .Net/c# and front end HTML/CSS/JavaScript classes!

***License***

   Licensing for this application is presently under review.  
   Please contact me for questions on how you may use the application.