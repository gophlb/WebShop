#### The projects:

- BLL: 
  The interface project between the web and the data access layer. Here happens the translation between the business/core and DAL objects
  
- Core:
  Basically ViewModels and objects of the application
  
- DAL:
  Where the access to the data happens. The managers and the objects, their respective interfaces and the edmx.
  
- ProductXmlGenerator:
  A console application to easily generate the XML with the products of the shop.
  
- Utils:
  As its name states, a project to put the utility classes. In this case, an extension to centralize the management of  exceptions.
  
- WebShop:
  The web itself. Part of MVC, part of WebApi (WebApiOverview.html / WebApiTest.html).
  


#### Additional technologies used:

- Backend:
  - Ninject
  
- Frontend:
  - JQuery
  - Bootstrap
  - JsRender (for template rendering)
  - Alertify
  - JQuery.validation
  - Google Maps / Places (for the shipping details form, autocomplete address)




#### Further comments:

  I've tried to separate all the layers working against interfaces where possible. This has favored the situation of changed-a-class-name-and-only-updated-two-classes.

  This way, changing the mode the classes access the data shold be completely transparent. Today the products come from an XML, tomorrow could come from database and the only thing we would have to develop or change sholud be the new class managing the db access.

  There are three types of data access: 
  - An XML for the products.
  - Session for the cart.
  - (File) Database for the orders and the clients.


  As stated in the comments inside the code, the email regex of jquery.validation doesn't work correctly and accepts emails like xxxx@xxxxx. After reading threads about this issue, the conclusion is that the best way to check the correctness of an email is sending an actual email to that address.


  I've tried to make the site as responsive as possible. In addition I've tried to make it simple, with no distractions and prepared to be intuitive and easy to use.


  I've developed two different pagination methods.
  - The first simply dumps a button for every page.
  - The second only dumps the first, the last, the current and (tries to) 5 prev and post.


  I've chosen the first one because there aren't a lot of products and it simplifies the navigation between pages (every page is always there to click).
  
  I've also developed two methods of client validation for the form:
  - The first one opens a temporary popover in the button with all the errors.
  - The second marks the first error with a red border and the error message in the title attr of the div.


  I've chosen the second because it behaves more like a step-by-step form and the popover is a very unconfortable method.
  
  
