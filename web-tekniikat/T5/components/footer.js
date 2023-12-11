class Footer extends HTMLElement {
    constructor() {
      super();
    }
  
    connectedCallback() {
      this.innerHTML = `
      <footer class="footer bg-light text-muted mt-2 pb-3">´
        <div class="footer-container ">
          <div class="row d-flex justify-content-md-center">
            <div class="col-lg-1">
              <img id="footer-logo" class="img-fluid" src="kuvat/logo.svg" alt="Yrityksen logo">
            </div>
            <div class="col-lg-3">
                <!--<p>El-Well Oy</p>-->
                <p>Y-tunnus: 1234567-8</p>
                <p>Puhelinnumero: 040 123 4567</p>
            </div>
            <div class="col-lg-3">
                <p>Sähköposti: mika.jarvenpaa@hamk.fi</p>
                <p>Osoite: Kaartokatu 2, 11000 Riihimäki</p>
            </div>
          </div>
        </div>
      </footer>
   `;
  }
}

customElements.define('footer-component', Footer);