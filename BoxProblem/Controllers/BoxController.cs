
        private BoxService service;

        public BoxController(ApplicationDbContext context)
        {
            service = new BoxService(context);
        }


        // GET: Employees
        public ActionResult Index()
        {
            return View(service.GetAllBoxes());
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoxInventory box)
        {
            if (ModelState.IsValid)
            {
                service.AddBox(box);
                return RedirectToAction("Index");
            }

            return View(box);
        }


       
        public ActionResult Edit(int id)
        {
            BoxInventory box = service.GetBoxById(id);
            return View(box);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BoxInventory box)
        {
            if (ModelState.IsValid)
            {
                service.SaveEdits(box);
                return RedirectToAction("Index");
            }
            return View(box);
        }
   
        public ActionResult Delete(int id)
        {
            BoxInventory box = service.GetBoxById(id);
            return View(box);
        }