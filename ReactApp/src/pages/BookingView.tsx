import React, { FunctionComponent } from 'react';
import Page from '../components/Page';

const BookingView: FunctionComponent = () => {

    return (
        <Page>
            <div className="container page-container">
                <div className="d-flex flex-column">
                    <div className="row">
                        <div className="col-xl-4 col-lg-4 col-md-5 col-sm-12 col-12 fp-text">
                            <div className="card card-align-height no-border-card bckg-blue">
                                <div className="card-header bckg-blue">
                                    <h2 className="h2 txt-white">BookingView</h2>
                                </div>
                                <div className="card-text bckg-blue">
                                    <p className="text txt-white">
                                        Vores nye system
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div className="col-xl-8 col-lg-8 col-md-7 col-sm-0 col-0 fp-img">
                            <div className="card card-align-height no-border-card">
                                <a href="/swagger" target="_blank" rel="noopener noreferrer" style={{fontSize: '60px'}}>
                                    Gå til swagger
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </Page>
    )
}

export default BookingView;