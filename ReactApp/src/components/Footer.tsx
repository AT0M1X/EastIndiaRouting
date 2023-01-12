const Footer = () => {
    return (
      <footer>
        <div className="footer">
          <div className="container">
            <div className="row">
              <div className="col">
                <p className="h5 weight-semibold mb-4">Ansvarlig myndighed</p>
                <svg width="200" height="50" role="img" aria-label="UVM Logo">
                  <image href="https://cf-cdn.xn--testogprver-ngb.dk/content/static/logo/uvm.svg" width="200" height="50" />
                </svg>
              </div>
              <div className="col">
                <p className="h5 weight-semibold mb-4">Kontakt</p>
              </div>
              <div className="col">
                <p className="h5 weight-semibold mb-4">Hjælpende links</p>
              </div>
              <div className="col">
                <p className="h5 weight-semibold mb-4">Webtilgængelighed og cookies</p>
              </div>
            </div>
          </div>
        </div>
      </footer>
    )
  }

  export default Footer;