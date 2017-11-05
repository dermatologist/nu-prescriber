# Contributing 

## Resources for Getting Started


## Reporting Bugs


### Bug report contents


## Requesting New Features


## Contributing (Step-by-step)

1. [Fork the repo](http://help.github.com/fork-a-repo) on which you're working, clone your forked repo to your local computer, and set up the upstream remote:

        git clone git://github.com/YourGitHubUserName/nu-prescriber.git
        git remote add upstream https://github.com/dermatologist/nu-prescriber.git

2. Checkout out a new local branch based on your master and update it to the latest. The convention is to name the branch after the current ticket, e.g. TRUNK-123:

        git checkout -b TRUNK-123 master
        git clean -df
        git pull --rebase upstream master

 > Please keep your code clean. If you find another bug, you want to fix while being in a new branch, please fix it in a separated branch instead.


3. Push the branch to your fork. Treat it as a backup.

        git push origin TRUNK-123

4. Code
  * Adhere to common conventions you see in the existing code
  * Include tests, and ensure they pass
  * Search to see if your new functionality has been discussed.

5. Follow the Coding Conventions.

 
6. Commit

  For every commit please write a short (max 72 characters) summary in the first line followed with a blank line and then more detailed descriptions of the change. Use markdown syntax for simple styling. Please include any issue numbers in your summary.
  
        git commit -m "TRUNK-123: Put change summary here (can be a ticket title)"

  **NEVER leave the commit message blank!** Provide a detailed, clear, and complete description of your commit!

7. Issue a Pull Request

  Before submitting a pull request, update your branch to the latest code.
  
        git pull --rebase upstream master

  If you have made many commits, we ask you to squash them into atomic units of work. Most of tickets should have one commit only, especially bug fixes, which makes them easier to back port.

        git checkout master
        git pull --rebase upstream master
        git checkout TRUNK-123
        git rebase -i master

  Make sure all unit tests still pass:

        mvn clean package

  Push changes to your fork:

        git push -f

  In order to make a pull request,
  * Navigate to the repository you just pushed to.
  * Click "Pull Request".
  * Write your branch name in the branch field (this is filled with "master" by default)
  * Click "Update Commit Range".
  * Ensure the changesets you introduced are included in the "Commits" tab.
  * Ensure that the "Files Changed" incorporate all of your changes.
  * Fill in some details about your potential patch including a meaningful title.
  * Click "Send pull request".

  Thanks for that -- we'll get to your pull request ASAP. We love pull requests!

## Responding to Feedback

  
## Other Resources


### Interact with the community


### Additional Resources

