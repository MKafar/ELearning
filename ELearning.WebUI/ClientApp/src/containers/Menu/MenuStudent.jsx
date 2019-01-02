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
            <Menu vertical>
                <Link to="/home">
                    <Menu.Item
                        name='home'
                        active={activeItem === 'home'}
                        onClick={this.handleItemClick} />
                </Link>
                <Link to="/logout">
                    <Menu.Item
                        name='wyloguj'
                        active={activeItem === 'wyloguj'}
                        onClick={this.handleItemClick} />
                </Link>
            </Menu>
        )
    }
}
export default MenuStudent;
