<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/PatentDepartment/UM/AppNumberRequest"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.PvUmAdapter\XMLSchemas\REG_UM_App_Number_Request.xsd" workingxmlfile="REG_UM_App_Number_Request.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<newline/>							<paragraph paragraphtag="h3">								<properties align="center"/>								<children>									<text fixtext="Справка за статус  на полезен модел по заявителски номер - входни параметри"/>								</children>							</paragraph>							<newline/>							<newline/>							<table>								<properties align="center" border="0" width="100%"/>								<styles width="50%"/>								<children>									<tablebody>										<children>											<tablerow>												<children>													<tablecell>														<children>															<text fixtext="Заявителски номер">																<styles font-weight="bold"/>															</text>														</children>													</tablecell>													<tablecell>														<children>															<template match="n1:getUtilityModelByAppNum" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<template match="n1:AppNum" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</template>														</children>													</tablecell>												</children>											</tablerow>										</children>									</tablebody>								</children>							</table>							<newline/>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>