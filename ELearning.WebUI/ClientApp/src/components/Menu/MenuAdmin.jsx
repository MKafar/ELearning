import React, { Component } from 'react'
import { Menu } from 'semantic-ui-react'

import "./MenuAdmin.scss";

class MenuAdmin extends Component {
    state = { activeItem: 'home' }

    handleItemClick = (e, { name }) => this.setState({ activeItem: name })

    render() {
        const { activeItem } = this.state;

        return (
            <Menu vertical>
                <Menu.Item
                    name='home'
                    active={activeItem === 'home'}
                    onClick={this.handleItemClick}
                />
                <Menu.Item
                    name='zadanie'
                    active={activeItem === 'zadanie'}
                    onClick={this.handleItemClick}
                />
                <Menu.Item
                    name='laboratorium'
                    active={activeItem === 'laboratorium'}
                    onClick={this.handleItemClick}
                />
                <Menu.Item
                    name='student'
                    active={activeItem === 'student'}
                    onClick={this.handleItemClick}
                />
                <Menu.Item
                    name='wyloguj'
                    active={activeItem === 'wyloguj'}
                    onClick={this.handleItemClick}
                />
            </Menu>
        )
    }
}
export default MenuAdmin;
