This theme is developed for docs.aspose.com. 
It is based on Docsy https://www.docsy.dev/ and Hugo Book https://github.com/alex-shpak/hugo-book Hugo themes.

# F.A.Q.

## How to setup theme

1. First of all you need to install npm dependencies:
    
    ``` 
        sudo npm install -D --save autoprefixer
        sudo npm install -D --save postcss-cli 
    ```

2. Start Hugo server
    ```
        hugo server -D
    ```

## Config.toml Params

1. **topbar_search_active** — Shows/Hide topbar search field.


## Page Variables
1. **showChildPages: true** - Shows the list of child pages in the bottom of the current page.


## Shortcodes — use in **.md** files
1. ``` {< emoticons/tick >}} ``` — to insert emoticon-tick.
2. ``` {{< emoticons/cross >}} ``` — to insert emoticon-cross.