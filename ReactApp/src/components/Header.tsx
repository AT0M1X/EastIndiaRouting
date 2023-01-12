import { FunctionComponent } from 'react';
import { ReactComponent as LogoSvg } from '../assets/img/logo.svg';
import { useLocation, Link } from 'react-router-dom';
import { MenuSetup, Side } from '../Routing';

const Header: FunctionComponent = () => {
    const location = useLocation();
  
    return (
      <header className="header">
        <div className="portal-header">
          <div className="container portal-header-inner">
            <LogoSvg className="mr-3" /><span><Link className="header-title" to={MenuSetup[Side.Home].path}>Nyt system</Link></span>
            <button className="button button-tertiary button-menu-open js-menu-open ml-auto s-print-none" aria-haspopup="menu" title="Åben mobil menu">Menu</button>
          </div>
        </div>
  
        <div className="overlay" />
        <nav className="nav">
          <button className="button button-secondary button-menu-close js-menu-close" title="Luk mobil menu"><svg className="icon-svg " focusable="false" aria-hidden="true" ><use xlinkHref="#close"></use></svg>Luk</button>
    
          <div className="navbar navbar-primary">
            <div className="container navbar-inner">
              <ul className="nav-primary">
                {
                  MenuSetup.filter(m => m.menuitem).map((item, i) =>
                    <li key={i} className={location.pathname === item.path || (item.prefix && location.pathname.startsWith(item.path)) ? "current" : ""}>
                      <Link className="nav-link" to={item.path}>
                        <span>{item.menuTekst}</span>
                      </Link>
                    </li>)
                }
              </ul>
            </div>
          </div>
          <div className="solution-info-mobile">
            <p className="bold">Nyt system</p>
            <p>Support: XX XX XX xx</p>
          </div>
        </nav>
      </header>
    )
  }
  
  export default Header;