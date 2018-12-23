import React, { Component } from 'react'
import { Menu } from 'semantic-ui-react'

import "./Menu.scss";

class menu extends Component {
    state = { activeItem: 'home' }

    handleItemClick = (e, { name }) => this.setState({ activeItem: name })

    render() {
        const { activeItem } = this.state

        return (
            <Menu inverted vertical>
                <Menu.Item
                    name='home'
                    active={activeItem === 'home'}
                    onClick={this.handleItemClick}
                />
                <Menu.Item
                    name='coding'
                    active={activeItem === 'coding'}
                    onClick={this.handleItemClick}
                />
            </Menu>
        )
    }
}
export default menu;
