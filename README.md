
<p align="center">
    <img src="https://img.shields.io/badge/Unity%20Version-2021.3.5f1-success" alt="Unity Version">
</p>

# Photon ( PUN ) Educational Project
Photon PUN is a powerful networking engine that allows developers to easily create and manage multiplayer games across different platforms.


# Overview
The game has up to 4 players and a custom sized arena based on the number of players in the room. This is mostly to showcase several concepts around syncing scenes: how to deal with players when loading different scenes and what could possibly go wrong when doing so.

To prevent players from just walking around and doing nothing, we have implemented a basic firing system coupled with a player's health management. By doing so, we are learning how to synchronize variables across the network.

When a player's health reaches 0, it's game over and they leave the arena. They are then presented with the intro screen again, allowing them to start a new game if they wish.
