<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/BABH/BABHZhS/RegisteredAnimalsByCategoryRequest"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\Projects\eGov\RegiX\RegiX.BABHZhSAdapter\XMLSchemas\RegisteredAnimalsByCategoryRequest.xsd" workingxmlfile="RegisteredAnimalsByCategoryRequest.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:RegisteredAnimalsByCategoryRequest" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Входни параметри на справка за вписани животни в животновъдни обекти по категории"/>										</children>									</paragraph>									<table>										<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>										<children>											<tablebody>												<children>													<tablerow>														<children>															<tablecell>																<properties width="355"/>																<children>																	<text fixtext="ЕГН на земеделски производител">																		<styles font-style="italic"/>																	</text>																</children>															</tablecell>															<tablecell>																<children>																	<template match="n1:EGN" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<styles font-weight="bold"/>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>													<tablerow>														<children>															<tablecell>																<properties width="355"/>																<children>																	<text fixtext="Дата на актуалност на данните">																		<styles font-style="italic"/>																	</text>																</children>															</tablecell>															<tablecell>																<children>																	<template match="n1:ValidDate" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<styles font-weight="bold"/>																				<format string="DD.MM.YYYY" datatype="date"/>																			</content>																			<text fixtext=" г.">																				<styles font-weight="bold"/>																			</text>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>												</children>											</tablebody>										</children>									</table>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>