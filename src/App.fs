module App

open Browser
open Feliz
open Elmish
open Feliz.UseMediaQuery

let useResponsiveExample = React.functionComponent(fun () ->
    let width = React.useResponsive(defaultBreakpoints)

    Html.div [
        prop.text (width |> string)
    ])

let useMediaQueryExample = React.functionComponent(fun () ->
    let isMax500 = React.useMediaQuery("(max-width: 500px)")

    Html.div [
        if isMax500 then 
            prop.text "500px or less"
        else
            prop.text "More than 500px"
    ])

let render = React.functionComponent(fun () ->
    let width = React.useResponsive(defaultBreakpoints)
    
    Html.div [
        prop.style [
            let bgColor = 
                match width with
                | ScreenSize.Mobile -> color.white
                | ScreenSize.MobileLandscape -> color.whiteSmoke
                | ScreenSize.Tablet -> color.darkGray
                | ScreenSize.Desktop -> color.gray
                | ScreenSize.WideScreen -> color.red
            
            style.padding 100
            style.display.flex
            style.flexDirection.column
            style.alignItems.center            
            style.justifyContent.center
            style.backgroundColor bgColor
        ]
        prop.children [
            useResponsiveExample ()
            useMediaQueryExample ()
        ]
    ]
)

ReactDOM.render(render, document.getElementById "feliz-app")