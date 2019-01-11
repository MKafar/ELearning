import React, { Component } from 'react';
import { Menu } from 'semantic-ui-react';
import { Link } from 'react-router-dom';

import "./MenuAdmin.scss";

class MenuAdmin extends Component {
    state = { activeItem: 'home' }

    handleItemClick = (e, { name }) => this.setState({ activeItem: name })

    render() {
        const { activeItem } = this.state;

        return (
            <div className='adminMenuContainer'>
                <Menu vertical className='adminMenu'>
                    <Menu.Item
                        as={Link}
                        to="/admin"
                        name='home'
                        active={activeItem === 'home'}
                        onClick={this.handleItemClick} />
                    <Menu.Item
                        as={Link}
                        to="/admin/exercises"
                        name='zadanie'
                        active={activeItem === 'zadanie'}
                        onClick={this.handleItemClick} />

                    <Menu.Item
                        as={Link}
                        to="/admin/subject"
                        name='przedmiot'
                        active={activeItem === 'przedmiot'}
                        onClick={this.handleItemClick} />
                    <Menu.Item
                        as={Link}
                        to="/admin/students"
                        name='student'
                        active={activeItem === 'student'}
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
export default MenuAdmin;
