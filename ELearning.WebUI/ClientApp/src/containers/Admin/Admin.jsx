import React, { Component } from 'react';


import './Admin.scss';


import MenuAdmin from '../../containers/Menu/MenuAdmin';


class Admin extends Component {

    render() {

        return (
            <div className='admin'>
                <div className='menu'>
                    <MenuAdmin />
                </div>
            </div>
        );
    }
}

export default Admin;