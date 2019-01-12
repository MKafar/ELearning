import React, { Component } from 'react';
import { Menu } from 'semantic-ui-react';
import { Link } from 'react-router-dom';

import "./MenuStudent.scss";

class MenuStudent extends Component {
    state = { activeItem: 'home' }

    handleItemClick = (e, { name }) => this.setState({ activeItem: name })

    render() {
        const { activeItem } = this.state

        return (
            <div className='student'>
                <Menu vertical className='studentMenu'>
                    <Menu.Item
                        as={Link}
                        to="/student"
                        name='home'
                        active={activeItem === 'home'}
                        onClick={this.handleItemClick} />
                    <Menu.Item
                        as={Link}
                        to="/"
                        name='wyloguj'
                        onClick={this.props.onClearUser} />
                </Menu>
            </div>
        )
    }
}
export default MenuStudent;
