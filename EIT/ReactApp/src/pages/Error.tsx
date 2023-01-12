import React, { FunctionComponent } from 'react';
import { Link } from 'react-router-dom';
import Page from '../components/Page';
import { MenuSetup, Side } from '../Routing';

const ErrorPage: FunctionComponent = () => {

  return (
    <Page>
      <div className="container page-container">
        <h1>Denne side kan ikke vises</h1>
        <p>Der er sket en fejl. Gå tilbage til <Link to={MenuSetup[Side.Forside].path}>forsiden</Link>.</p>
      </div>
    </Page>
  )
}

export default ErrorPage;