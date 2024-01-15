class Hero extends HTMLElement {
    constructor() {
      super();
    }
  
    connectedCallback() {
      this.innerHTML = `
      <section id="hero" class="bg-img">
        <div class="container-fluid text-uppercase">
          <!-- NAVI -->
          <nav id="change" class="navbar fixed-top navbar-expand-lg">
            <a class="navbar-brand" href="#">
                <img id="nav-logo" src="kuvat/elwell-white.svg" alt="logo">
            </a>

            <!-- SIDENAV -->
            <nav class="sideNav">    
              <button id="sideNav-btn" class="btn" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasExample" aria-controls="offcanvasExample">
                <i class="fa-solid fa-bars"></i>
              </button>
              <div class="offcanvas offcanvas-start" tabindex="-1" id="offcanvasExample" aria-labelledby="offcanvasExampleLabel">
                <div class="offcanvas-header">
                    <a class="navbar-brand" href="#">
                        <img id="nav-logo" src="kuvat/elwell-white.svg" alt="logo">
                    </a>
                    <button type="button" class="btn" data-bs-dismiss="offcanvas">
                      <i class="fa-solid fa-x"></i>
                    </button>
                </div>
                <div class="offcanvas-body">
                    <ul class="navbar-nav text-white">
                        <li class="yleista nav-item">
                          <a class="nav-link" href="index.html">Yleistä</a>
                        </li>
                        <li class="joustorahoitus nav-item">
                          <a class="nav-link" href="joustorahoitus.html">Joustorahoitus</a>
                        </li>
                        <li class="palvelut nav-item">
                          <a class="nav-link" href="palvelut.html">Palvelut</a>
                        </li>
                        <li class="yhteystiedot nav-item">
                          <a class="nav-link" href="yhteystiedot.html">Yhteystiedot</a>
                        </li>
                    </ul>
                </div>
              </div>
            </nav>

            <div class="collapse navbar-collapse justify-content-end" id="navbarNav">
              <ul class="navbar-nav">
                <li class="yleista nav-item">
                  <a class="nav-link" href="index.html">Yleistä</a>
                </li>
                <li class="joustorahoitus nav-item">
                  <a class="nav-link" href="joustorahoitus.html">Jousto&shy;rahoitus</a>
                </li>
                <li class="palvelut nav-item">
                  <a class="nav-link" href="palvelut.html">Palvelut</a>
                </li>
                <li class="yhteystiedot nav-item">
                  <a class="nav-link" href="yhteystiedot.html">Yhteystiedot</a>
                </li>
              </ul>
            </div>
          </nav>
      
      <!-- HERO -->
      <div class="pt-5 text-white container d-flex flex-column align-items-center">
        <h1 id="otsikko">Otsikko</h1>
        <h3 id="alaotsikko">Alaotsikko</h3>
      </div>
    </div>
  </section>
`;
  }
}

customElements.define('hero-component', Hero);